using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Domain.UserProfile.Commands
{
   public class UserProfileGetCommand: IRequest<UserProfileReadModel>
    {
        public UserProfileGetCommand(Guid userId)
        {
            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}
