using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using TrainDTrainorV2.Core.Services;

namespace TrainDTrainorV2.Core.Domain.User.Handlers
{
    public class UserSendOTPCommandHandler: RequestHandlerBase<UserManagementCommand<UserSendOTPModel>, UserReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly ISMSTemplateService _sMSTemplateService;
        private readonly IMapper _mapper;
        private readonly string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        public UserSendOTPCommandHandler(ILoggerFactory loggerFactory, TrainDTrainorContext dataContext, ISMSTemplateService sMSTemplateService, IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;         
            _mapper = mapper;
            _sMSTemplateService = sMSTemplateService;
        }

        protected override async Task<UserReadModel> ProcessAsync(UserManagementCommand<UserSendOTPModel> message, CancellationToken cancellationToken)
        {
            var otp = GenerateRandomOTP(4, saAllowedCharacters);
            var model = message.Model;

            var user = await _dataContext.Users.GetByKeyAsync(model.Id)
                .ConfigureAwait(false);

            if (user == null)
                throw new DomainException(422, $"User with Id '{model.Id}' not found.");
            if (user.PhoneNumber != model.PhoneNumber)
                throw new DomainException(422, $"User with phone number '{model.PhoneNumber}' not exist in system.");

            var result = await  _sMSTemplateService.SendOTP(user.PhoneNumber, otp).ConfigureAwait(false);
            if (result == false) throw new DomainException(422, $"Unable to send OTP '{model.PhoneNumber}' please try again later or contact administrator.");

            user.OTP = otp;
            user.Updated = DateTimeOffset.UtcNow;
            user.IsPhoneNumberConfirmed = false;
            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var readModel = _mapper.Map<UserReadModel>(user);
            return readModel;


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
