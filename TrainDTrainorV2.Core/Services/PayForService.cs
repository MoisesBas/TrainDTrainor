using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using TrainDTrainorV2.Core.Options;

namespace TrainDTrainorV2.Core.Services
{
   public class PayForService:IPayForService
    {
        private const char NewLineChar = '\n';
        private static HttpClient _client;
        private readonly IOptions<PayFortOptionConfiguration> _payForOptions;
        public PayForService(IOptions<PayFortOptionConfiguration> payForOptions)
        {
            _payForOptions = payForOptions;
            if (_payForOptions == null)
                throw new ArgumentNullException(nameof(_payForOptions));

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_payForOptions.Value.TEST_TOKEN_URL);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_client.DefaultRequestHeaders.Add("Authorization", GetAuthorizationHeaderValue(privateKey));
            //_client.DefaultRequestHeaders.Add("User-agent", string.Format("Start.Net {0}", CoreAssembly.Version.ToString()));
        }
    }
}
