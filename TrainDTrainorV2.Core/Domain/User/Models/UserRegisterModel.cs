using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Domain.Models
{
    public class UserRegisterModel
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAgree { get; set; }
    }
}
