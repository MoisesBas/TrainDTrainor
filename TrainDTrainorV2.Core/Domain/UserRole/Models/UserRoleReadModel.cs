using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Definitions;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.Models;

namespace TrainDTrainorV2.Core.Domain.UserRole.Models
{
   public class UserRoleReadModel: EntityReadModel<Guid>, ITrackConcurrency
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public int UserType { get; set; }
        public UserReadModel  User { get; set; }
    }
}
