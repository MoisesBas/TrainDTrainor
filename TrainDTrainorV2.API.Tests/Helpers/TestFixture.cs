using KickStart;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Options;

namespace TrainDTrainorV2.API.Tests.Helpers
{
    public class TestFixture: IDisposable
    {
        public TestServer Server { get; set; }
        public HttpClient Client { get; set; }

        public TestFixture()
        {
            var enviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Test";
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{enviromentName}.json", true);

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton(p => configuration);
            services.AddLogging();
            services.AddOptions();

            services.KickStart(config => config
                .IncludeAssemblyFor<TrainDTrainorContext>()
                .IncludeAssemblyFor<TestFixture>()
                .Data(ConfigurationServiceModule.ConfigurationKey, configuration)
                .Data("hostProcess", "test")                
                .UseStartupTask());

            Server = new TestServer(Program.GetWebHostBuilder(null));
            var client = Server.CreateClient();
            Client = client;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
