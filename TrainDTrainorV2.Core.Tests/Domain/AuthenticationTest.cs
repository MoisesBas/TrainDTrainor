using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainDTrainorV2.Core.Domain.Authentication.Commands;
using TrainDTrainorV2.Core.Models;
using TrainDTrainorV2.Core.Security;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace TrainDTrainorV2.Core.Tests.Domain
{
    [Collection("DependencyInjectionCollection")]
    public class AuthenticationTest : DependencyInjectionBase
    {
        public AuthenticationTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
            : base(outputHelper, dependencyInjection)
        {
        }
    

        [Fact]
        public async Task LoginUser()
        {
            var mediator = ServiceProvider.GetService<IMediator>();           

            var userAgent = new UserAgentModel
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.84 Safari/537.36",
                Browser = "Chrome",
                DeviceBrand = "",
                DeviceFamily = "Other",
                DeviceModel = "",
                OperatingSystem = "Windows 10",
                IpAddress = "127.0.0.1"
            };

            var request = new TokenRequest
            {
                GrantType = "password",
                ClientId = "UnitTest",
                UserName = "string@gmail.com",
                Password = "P@ssw0rd1125"
            };

            var command = new AuthenticateCommand(userAgent, request);
            var result = await mediator.Send(command).ConfigureAwait(false);          

        }
    }
}
