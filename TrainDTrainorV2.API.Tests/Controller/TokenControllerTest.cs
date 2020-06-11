using MediatR;
using System;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.CommandQuery.Queries;
using FluentAssertions;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.Abstractions;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using Newtonsoft.Json;
using TrainDTrainorV2.Core.Security;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http.Formatting;
using System.Threading;

namespace TrainDTrainorV2.API.Tests.Controller
{
   
    public class TokenControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> webApplicationFactory;
        private HttpClient httpClient;

        public TokenControllerTest(WebApplicationFactory<Startup> webApplicationFactory)
        {
            this.webApplicationFactory = webApplicationFactory;
            this.httpClient = this.webApplicationFactory.CreateClient();         
            //this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Fact]
        public async Task ShouldNotAuthorized()
        {
            string URL = "api/token/test";
            var response = await this.httpClient.GetAsync(URL);
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);            
        }

        [Fact]
        public async Task ShouldBeAuthenticate()
        {
            //string URL = "api/token";
            //var model = JsonConvert.SerializeObject(new TokenRequest
            //{
            //    UserName = "test@gmail.com",
            //    Password = "P@ssw0rd1125",
            //    GrantType = "password",
            //    ClientId = "TrainDTrainor"
            //});
            //var httpContent = new StringContent(model, Encoding.UTF8, "application/json");            
            //var response = await this.httpClient.PostAsJsonAsync(URL, httpContent);
            //Assert.NotNull(response);
            var url = "https://localhost:44319/api/token";

            var model = new TokenRequest
             {
                 UserName = "test@gmail.com",
                 Password = "P@ssw0rd1125",
                 GrantType = "password",
                 ClientId = "TrainDTrainor"
             };

             var request = new HttpRequestMessage { RequestUri = new Uri(url) };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Method = HttpMethod.Post;
            request.Content = new ObjectContent<TokenRequest>(model, new JsonMediaTypeFormatter());

            HttpResponseMessage response = this.httpClient.SendAsync(request, new CancellationTokenSource().Token).Result;

            Assert.True(response.IsSuccessStatusCode);
            Assert.NotNull(response.Content);
        }

    }
}
