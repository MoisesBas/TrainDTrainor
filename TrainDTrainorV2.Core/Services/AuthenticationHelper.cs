using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using TrainDTrainorV2.Core.Options;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Services
{
    public class AuthenticationHelper : IAuthenticationHelper
    {
        private const char NewLineChar = '\n';
        private static HttpClient _client;
        private readonly IOptions<SMSConfiguration> _smsConfiguration;
        

        public AuthenticationHelper(IOptions<SMSConfiguration> smsConfiguration)
        {
            _smsConfiguration = smsConfiguration;
            _client = new HttpClient { BaseAddress = new Uri("https://" + this._smsConfiguration.Value.Uri) };
            _client.DefaultRequestHeaders.Add("Accept", " application/json");
        }

        public string CreateMacHash(long unixTime, string nonce)
        {

            var stringToHash = unixTime.ToString() + NewLineChar +
                nonce + NewLineChar +
                "POST" + NewLineChar +
                this._smsConfiguration.Value.EndPoint + NewLineChar +
                this._smsConfiguration.Value.Uri + NewLineChar +
                this._smsConfiguration.Value.Port + NewLineChar +
                NewLineChar;

            var secretBytes = System.Text.Encoding.UTF8.GetBytes(this._smsConfiguration.Value.ApiSecret);
            var sha256 = new HMACSHA256(secretBytes);
            var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(stringToHash));
            return System.Convert.ToBase64String(hashedBytes);
        }

        public async Task<HttpResponseMessage> SendMessage(string content, string mobileNumber)
        {
            try
            {
                var nonce = Guid.NewGuid().ToString();
                var unixTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                var hash = CreateMacHash(unixTime, nonce);
                var authorizationHeaderValue = $"MAC id=\"{this._smsConfiguration.Value.ApiKey}\", ts=\"{unixTime}\", nonce=\"{nonce}\", mac=\"{hash}\"";
                _client.DefaultRequestHeaders.Add("Authorization", authorizationHeaderValue);

                if (!mobileNumber.StartsWith("00") || !mobileNumber.StartsWith("+"))
                    mobileNumber = "+" + mobileNumber;

                mobileNumber = mobileNumber.Replace(" ", string.Empty);
                mobileNumber = mobileNumber.Replace("-", string.Empty);
                var parameters = JsonConvert.SerializeObject(new
                {
                    destination = mobileNumber,
                    message = content
                });

                var message = new StringContent(parameters, Encoding.UTF8, "application/json");
                return await _client.PostAsync(this._smsConfiguration.Value.EndPoint, message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
