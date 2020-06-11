using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using TrainDTrainorV2.Core.Models;
using TrainDTrainorV2.API.Middleware;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrainDTrainorV2.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using TrainDTrainorV2.Core.Extensions;
using Hangfire;

namespace TrainDTrainorV2.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.ConfigureKickStart(Configuration);
            var provider = services.BuildServiceProvider();
            
            //provider.GetService<TrainDTrainorContext>().Database.Migrate();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.ConfigureAuthentication(provider);
            services.ConfigureSwagger();
            services.ConfigureCors();
            services.ConfigureMvc();
            services.Configure<ApiBehaviorOptions>(o =>
                o.InvalidModelStateResponseFactory = a => new UnprocessableEntityObjectResult(new ErrorModel(a.ModelState))
            );
         
            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAll");
            app.UseMiddleware<JsonExceptionMiddleware>();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSwagger();
            app.ConfigureSwaggerUI();
            app.UseMvc();
           

            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                if (!serviceScope.ServiceProvider.GetService<TrainDTrainorContext>().AllMigrationsApplied())
                {
                    serviceScope.ServiceProvider.GetService<TrainDTrainorContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<TrainDTrainorContext>().EnsureSeeded();
                }

            }
        }
    }
}
