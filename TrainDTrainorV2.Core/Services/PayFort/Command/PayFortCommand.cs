using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Services.PayFort.Command
{
   public class PayFortCommand: IRequest<PayFortResponse>
    {
        public PayFortCommand(UserAgentModel userAgent, PayFortRequest payFortRequest, string coreAssembly)
        {
            UserAgent = userAgent;
            PayFortRequest = payFortRequest;
            CoreAssembly = coreAssembly;
        }

        public PayFortRequest PayFortRequest { get; set; }

        public UserAgentModel UserAgent { get; set; }
        public string CoreAssembly { get; set; }
    }
}
