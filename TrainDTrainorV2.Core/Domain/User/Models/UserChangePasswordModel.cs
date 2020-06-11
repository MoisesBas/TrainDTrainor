using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Domain.Models
{
    public class UserChangePasswordModel
    {
        public string CurrentPassword { get; set; }

        public string UpdatedPassword { get; set; }
    }
}
