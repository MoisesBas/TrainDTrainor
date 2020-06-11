using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Security;

namespace TrainDTrainorV2.Core.Services
{
   public class PayFortError
    {
        [JsonProperty(TokenConstants.Parameters.Error, NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        [JsonProperty(TokenConstants.Parameters.ErrorDescription, NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDescription { get; set; }
    }
}
