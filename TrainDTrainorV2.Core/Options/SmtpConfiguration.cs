﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Options
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public bool UseSSL { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
