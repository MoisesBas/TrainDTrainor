using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Security;
using Microsoft.Extensions.Logging;
using TrainDTrainorV2.Core.Services;
using TrainDTrainorV2.Core.Data.Entities;
using System.Transactions;
using TrainDTrainorV2.Core.Domain.UserRole.Models;

namespace TrainDTrainorV2.Core.Domain.User.Handlers
{
    public class UserRegisterCommandHandler : RequestHandlerBase<UserManagementCommand<UserRegisterModel>, UserReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ISMSTemplateService _sMSTemplateService;
        private readonly IMapper _mapper;
        private readonly string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        public UserRegisterCommandHandler(ILoggerFactory loggerFactory, TrainDTrainorContext dataContext,
            IPasswordHasher passwordHasher, IMapper mapper,
             ISMSTemplateService sMSTemplateService) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _sMSTemplateService = sMSTemplateService;
        }

        protected override async Task<UserReadModel> ProcessAsync(UserManagementCommand<UserRegisterModel> message, CancellationToken cancellationToken)
        {
            var otp = GenerateRandomOTP(4, saAllowedCharacters);
            var model = message.Model;
            using (var scope = await _dataContext.Database.BeginTransactionAsync(cancellationToken).ConfigureAwait(false))
            {
                try
                {
                    // check for existing user
                    var user = await _dataContext.Users
                        .GetByEmailAddressAsync(model.EmailAddress)
                        .ConfigureAwait(false); 

                    if (user != null)
                        throw new DomainException(422, $"User with email '{model.EmailAddress}' already exists.");

                    var passwordHashed = _passwordHasher
                        .HashPassword(model.Password);

                    user = new Data.Entities.User
                    {
                        EmailAddress = model.EmailAddress,
                        DisplayName = model.DisplayName,
                        PasswordHash = passwordHashed,
                        Created = DateTimeOffset.UtcNow,
                        Updated = DateTimeOffset.UtcNow,
                        PhoneNumber = model.PhoneNumber,
                        OTP = otp,
                        IsPhoneNumberConfirmed = false,
                        IsGlobalAdministrator = false
                    };

                    await _dataContext.Users
                        .AddAsync(user, cancellationToken)
                        .ConfigureAwait(false);

                    await _dataContext
                        .SaveChangesAsync(cancellationToken)
                        .ConfigureAwait(false);

                    
                    // convert to read model
                    var readModel = _mapper.Map<UserReadModel>(user);
                    var currentUser = _mapper.Map<Data.Entities.UserProfile>(user);

                    var roles = await _dataContext.Roles.GetByNameAsync(Data.Constants.Role.MemberName).ConfigureAwait(false); 
                    
                    var defaultRoles = _mapper.Map<Data.Entities.UserRole>(user);
                    defaultRoles.RoleId = roles.Id;
                    defaultRoles.UserType = (int)Enum.Roles.Trainee;

                    await _dataContext.UserRoles.AddAsync(defaultRoles, cancellationToken).ConfigureAwait(false); 
                    
                    await _dataContext.UserProfiles.AddAsync(currentUser, cancellationToken).ConfigureAwait(false);   
                    
                    var status =  await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

                    if(status != 0)
                    {
                        var result = await _sMSTemplateService.SendOTP(user.PhoneNumber, otp).ConfigureAwait(false);
                        if (result == false)
                        {
                            Logger.LogWarning($"Unable to send OTP '{model.PhoneNumber}' please try again later or contact administrator.");
                            throw new DomainException(422, $"Unable to send OTP '{model.PhoneNumber}' please try again later or contact administrator.");
                        }
                        else
                        {
                            scope.Commit();
                            return readModel;
                        }                       
                    }
                   
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex.Message);
                    scope.Rollback();
                    throw new DomainException(422, $"Unable to Register:'{ex.Message}', Please try again.");
                }
            }

            return null;
        }
        protected string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)
        {
            string sOTP = String.Empty;
            string sTempChars = String.Empty;
            Random rand = new Random();
            for (int i = 0; i < iOTPLength; i++)
            {
                int p = rand.Next(0, saAllowedCharacters.Length);
                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];
                sOTP += sTempChars;
            }
            return sOTP;

        }
    }
}
