using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainDTrainorV2.Core.Options;

namespace TrainDTrainorV2.Core.Services
{
    public class SMSTemplateService : ISMSTemplateService
    {
        private readonly IAuthenticationHelper _authenticationHelper;
       
        public SMSTemplateService(IAuthenticationHelper authenticationHelper)
        {
            _authenticationHelper = authenticationHelper;
        }
        public async Task<bool> SendOTP(string number, string message)
        {
           var result =  await _authenticationHelper.SendMessage(message, number).ConfigureAwait(false);
            if (result.StatusCode == System.Net.HttpStatusCode.OK) return true;
            return false;
        }
        public async Task<bool> ForApproval(string number, string message)
        {
            var result = await _authenticationHelper.SendMessage(message, number).ConfigureAwait(false);
            if (result.StatusCode == System.Net.HttpStatusCode.OK) return true;
            return false;
        }

    }
}
