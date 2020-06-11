using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TrainDTrainorV2.API.Tests.Helpers;
using TrainDTrainorV2.Core.Security;
using Xunit;

namespace TrainDTrainorV2.API.Tests.Controller
{
   public class TestController
    {
        private TestFixture _testFixture;

        public TestController()
        {
            _testFixture = new TestFixture();
        }
        [Fact]
        public async Task WhenPost_AuthenticateOk()
        {
            var response = await _testFixture.Client.PostAsync("/api/token"
               , new StringContent(
               JsonConvert.SerializeObject(new TokenRequest
               {
                   UserName = "test@gmail.com",
                   Password = "P@ssw0rd1125",
                   GrantType = "password",
                   ClientId = "TrainDTrainor"
               }),
           Encoding.UTF8,
           "application/json"));

            response.EnsureSuccessStatusCode();

            response.StatusCode.Should().Be(HttpStatusCode.OK);


           // var response = await _testFixture.Client.PostAsync("/api/token",);
            //var contents = await response.Content.ReadAsStringAsync();
            //Assert.True(response.StatusCode == HttpStatusCode.OK, $"Expected OK but received {response.StatusCode}");
        }
        [Fact]
        public async Task WhenGet_Test1()
        {
            
            //var response = await _testFixture.Client.GetAsync("/api/token/test1", builder);
            //var contents = await response.Content.ReadAsStringAsync();
            //Assert.True(response.StatusCode == HttpStatusCode.OK, $"Expected OK but received {response.StatusCode}");


            // var response = await _testFixture.Client.PostAsync("/api/token",);
            //var contents = await response.Content.ReadAsStringAsync();
            //Assert.True(response.StatusCode == HttpStatusCode.OK, $"Expected OK but received {response.StatusCode}");
        }
    }
}
