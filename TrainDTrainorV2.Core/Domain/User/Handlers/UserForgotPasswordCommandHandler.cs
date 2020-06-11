using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Options;
using TrainDTrainorV2.Core.Security;
using TrainDTrainorV2.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
namespace TrainDTrainorV2.Core.Domain.User.Handlers
{
    public class UserForgotPasswordCommandHandler : RequestHandlerBase<UserManagementCommand<UserForgotPasswordModel>, UserReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IOptions<HostingConfiguration> _hostingOptions;


        public UserForgotPasswordCommandHandler(ILoggerFactory loggerFactory, TrainDTrainorContext dataContext, IPasswordHasher passwordHasher, IMapper mapper, IEmailTemplateService emailTemplateService, IOptions<HostingConfiguration> hostingOptions) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _emailTemplateService = emailTemplateService;
            _hostingOptions = hostingOptions;
        }

        protected override async Task<UserReadModel> ProcessAsync(UserManagementCommand<UserForgotPasswordModel> message, CancellationToken cancellationToken)
        {
            var model = message.Model;

            // check for existing user
            var user = await _dataContext.Users
                .GetByEmailAddressAsync(model.EmailAddress)
                .ConfigureAwait(false);

            if (user == null)
                throw new DomainException(422, $"User with email '{model.EmailAddress}' not found.");


            var resetToken = Guid.NewGuid().ToString("N");
            var resetHash = _passwordHasher.HashPassword(resetToken);

            user.ResetHash = resetHash;
            user.UpdatedBy = "system";
            user.Updated = DateTimeOffset.UtcNow;

            await _dataContext
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            var emailModel = new UserResetPasswordEmail
            {
                EmailAddress = user.EmailAddress,
                DisplayName = user.DisplayName,
                ResetToken = resetToken,
                UserAgent = message.UserAgent,
                ResetLink = $"{_hostingOptions.Value.ClientDomain}#/reset-password/{resetToken}"
            };

            await _emailTemplateService.SendResetPasswordEmail(emailModel).ConfigureAwait(false);

            // convert to read model
            var readModel = _mapper.Map<UserReadModel>(user);

            return readModel;
        }
    }
}
