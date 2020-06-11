using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.User.Commands;
using Microsoft.Extensions.Logging;

namespace TrainDTrainorV2.Core.Domain.User.Handlers
{
    public class UserVerifyOTPCommandHandler: RequestHandlerBase<UserManagementCommand<UserVerifyOTPModel>, UserReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        public UserVerifyOTPCommandHandler(ILoggerFactory loggerFactory, TrainDTrainorContext dataContext, IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;            
            _mapper = mapper;
        }
        protected override async Task<UserReadModel> ProcessAsync(UserManagementCommand<UserVerifyOTPModel> message, CancellationToken cancellationToken)
        {
            
            var model = message.Model;

            var user = await _dataContext.Users.GetByKeyAsync(model.Id)
                .ConfigureAwait(false);

            if (user == null)
                throw new DomainException(422, $"User with Id '{model.Id}' not found.");
            if (user.PhoneNumber != model.PhoneNumber)
                throw new DomainException(422, $"User with phone number '{model.PhoneNumber}' not exist in system.");

            if(user.OTP != model.OTP)
                throw new DomainException(422, $"The '{model.OTP}' account verification number is not valid.,");

            user.IsPhoneNumberConfirmed = true;
            user.Updated = DateTimeOffset.UtcNow;
            
            await _dataContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            var readModel = _mapper.Map<UserReadModel>(user);
            return readModel;


        }
    }
}
