using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Domain.UserProfile.Commands
{
   public class UserProfileCommand:IRequest<UserProfileReadModel>
    {
        public UserProfileCommand(UserProfileUpdateModel userProfile)
        {
            UserProfile = userProfile;
        }
        public UserProfileUpdateModel UserProfile { get; set; }
    }
}
