﻿using System;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.Models
{
    public class UserResetPasswordEmail
    {
        public string DisplayName { get; set; }
        public string EmailAddress { get; set; }
        public string ResetToken { get; set; }
        public string ResetLink { get; set; }

        public UserAgentModel UserAgent { get; set; }
    }
}
