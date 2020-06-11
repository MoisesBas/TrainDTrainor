using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.UserRole.Models
{
    public class UserRoleCreateModel: EntityCreateModel<Guid>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public int UserType { get; set; }
    }
}
