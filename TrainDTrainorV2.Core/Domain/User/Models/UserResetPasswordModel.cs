using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Domain.Models
{
    public class UserResetPasswordModel
    {
        public string EmailAddress { get; set; }
        public string ResetToken { get; set; }
        public string UpdatedPassword { get; set; }
    }
}
