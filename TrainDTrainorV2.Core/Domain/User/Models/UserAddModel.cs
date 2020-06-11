using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Domain.User.Models
{
    public class UserAddModel
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAgree { get; set; }
        public Guid? RoleId { get; set; }
    }
}
