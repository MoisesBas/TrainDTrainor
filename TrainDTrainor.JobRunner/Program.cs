using System;
using Hangfire;
using Hangfire.SqlServer;
using TrainDTrainorV2.Core.Data;
using TrainDTrainorV2.Core.Options;
using TrainDTrainorV2.Core.Runner;
using KickStart;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;

namespace TrainDTrainor.JobRunner
{
    public class Program
    {
        static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Debug()
                .WriteTo.LiterateConsole()
                .WriteTo.RollingFile("log-{Date}.txt", LogEventLevel.Debug)
                .CreateLogger();

            try
            {
                Log.Information("Starting JobRunner host");

                var enviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
                var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()                    
                      
                    .AddJsonFile("appsettings.json")
                    .AddJsonFile($"appsettings.{enviromentName}.json", true);

                var configuration = builder.Build();

                var services = new ServiceCollection();
                
                services.AddSingleton(p => configuration);
                services.AddLogging(b => b.AddSerilog());
               
                services.AddOptions();

                services.KickStart(config => config
                    .IncludeAssemblyFor<TrainDTrainorContext>()
                    .Data(ConfigurationServiceModule.ConfigurationKey, configuration)
                    .Data("hostProcess", "runner")
                    .UseAutoMapper()                    
                    .UseStartupTask()
                );
              
                var connectionString = configuration.GetConnectionString("TrainDTrainor");
                var storageOptions = new SqlServerStorageOptions();
                GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString, storageOptions);

                var serverOptions = new BackgroundJobServerOptions();

                using (var webJobHost = new WebJobHost())
                using (var backgroundJobServer = new BackgroundJobServer(serverOptions))
                {
                    
                    webJobHost.RunAndBlock();
                }


                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
