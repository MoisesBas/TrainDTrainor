﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Models
{
    public class UserAgentModel
    {
        public string UserAgent { get; set; }

        public string Browser { get; set; }
        public string OperatingSystem { get; set; }

        public string DeviceFamily { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceModel { get; set; }

        public string IpAddress { get; set; }

    }
}
