using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Events;

namespace TrainDTrainorV2.API
{
    public class Program
    {
        public static void Main(string[] args)
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
                Log.Information("Starting web host");
                BuildWebHost(args).Run();

            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
           
        }
        public static IWebHost BuildWebHost(string[] args)
        {
            var webHostBuilder = GetWebHostBuilder(args);
            return webHostBuilder.Build();
        }
        public static IWebHostBuilder GetWebHostBuilder(string[] args)=>
             WebHost.CreateDefaultBuilder(args)            
            .UseKestrel(d=> { d.Limits.MaxRequestBodySize = null; })            
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseSerilog()
            .UseStartup<Startup>();
        // {
        //var webHostBuilder = new WebHostBuilder()
        //    .UseKestrel()
        //    .UseContentRoot(appRootPath)
        //    .UseStartup<Startup>();
        //return webHostBuilder;
        // }
    }
}
