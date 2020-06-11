using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.UserProfile.Commands;

namespace TrainDTrainorV2.Core.Domain.UserProfile.Handlers
{
    public class UserProfileGetCommandHandler : RequestHandlerBase<UserProfileGetCommand, UserProfileReadModel>
    {
        private readonly TrainDTrainorContext _dataContext;
        private readonly IMapper _mapper;
        public UserProfileGetCommandHandler(ILoggerFactory loggerFactory,
            TrainDTrainorContext dataContext,
            IMapper mapper) : base(loggerFactory)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        protected override async Task<UserProfileReadModel> ProcessAsync(UserProfileGetCommand message, CancellationToken cancellationToken)
        {
            if (message.UserId == null) throw new DomainException(422, $"User Id is null: '{message.UserId}', Please try again.");

            var currentUser = await _dataContext.UserProfiles
                                   .ByUserId(message.UserId)
                                   .ConfigureAwait(false);
            if(currentUser == null) throw new DomainException(422, $"User Profile with userId: '{message.UserId}' not exists., Please try again.");
            if (currentUser.FileId.HasValue)
            {
                var pic = _dataContext.ProfilePicFiletable
                                            .GetProfilePicId(currentUser.FileId)
                                            .FirstOrDefault();
                var result = _mapper.Map<UserProfileReadModel>(currentUser);
                var output = _mapper.Map(pic, result);
                return output;
            }
            return _mapper.Map<UserProfileReadModel>(currentUser); 

        }
    }
}
