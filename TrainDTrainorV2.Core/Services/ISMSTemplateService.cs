using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Services
{
   public interface ISMSTemplateService
    {
        Task<bool> SendOTP(string number, string message);
        Task<bool> ForApproval(string number, string message);
    }
}
