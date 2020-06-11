using System;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Options;
using KickStart;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrainDTrainorV2.Core.Tests
{
    public class DependencyInjectionFixture : IDisposable
    {
        public DependencyInjectionFixture()
        {
            var enviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Test";
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
                //.AddJsonFile($"appsettings.{enviromentName}.json", true);

            var configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddSingleton(p => configuration);
            services.AddLogging();
            services.AddOptions();

            services.KickStart(config => config
                .IncludeAssemblyFor<TrainDTrainorContext>()
                .IncludeAssemblyFor<DependencyInjectionFixture>()
                .Data(ConfigurationServiceModule.ConfigurationKey, configuration)
                .Data("hostProcess", "test")
                .UseAutoMapper()
                .UseStartupTask()
            );
            
        }

        public IServiceProvider ServiceProvider => Kick.ServiceProvider;

        public void Dispose()
        {

        }
    }
}