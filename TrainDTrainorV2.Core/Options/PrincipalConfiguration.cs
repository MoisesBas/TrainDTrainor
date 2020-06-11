using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Options
{
    public class PrincipalConfiguration
    {
        public string AudienceId { get; set; }
        public string AudienceSecret { get; set; }
        public TimeSpan TokenExpire { get; set; } = TimeSpan.FromMinutes(30);
        public TimeSpan RefreshExpire { get; set; } = TimeSpan.FromDays(30);
    }
}
