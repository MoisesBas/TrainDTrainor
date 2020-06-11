using MediatR;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Commands;
using TrainDTrainorV2.Core.Models;
using TrainDTrainorV2.Core.MongoDB.Domain.CourseMaterial.Models;

namespace TrainDTrainorV2.Core.Tests.Domain
{
    [Collection("DependencyInjectionCollection")]
    public  class CourseMaterialTest: DependencyInjectionBase
    {
        public CourseMaterialTest(ITestOutputHelper outputHelper, DependencyInjectionFixture dependencyInjection)
            : base(outputHelper, dependencyInjection)
        {

        }
        [Fact]
        public async Task UploadMaterials()
        {
            var mediator = ServiceProvider.GetService<IMediator>();
            mediator.Should().NotBeNull();

            var files = File.OpenRead(@"E:\logo.png");
            files.Should().NotBeNull();

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
            var courseMaterial = new CreateCourseMaterialModel
            {
               // FileUpload = files,
                //Name = files.Name,               
               
            };                     
            var uploadCommand = new CourseMaterialCommand(userAgent, courseMaterial);
            var result = await mediator.Send(uploadCommand).ConfigureAwait(false);
            result.Should().NotBeNull();
        }
    }
}
