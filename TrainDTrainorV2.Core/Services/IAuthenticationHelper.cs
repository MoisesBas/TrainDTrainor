using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Services
{
public interface IAuthenticationHelper
    {
        string CreateMacHash(long unixTime, string nonce);
        Task<HttpResponseMessage> SendMessage(string content, string mobileNumber);
    }
}
