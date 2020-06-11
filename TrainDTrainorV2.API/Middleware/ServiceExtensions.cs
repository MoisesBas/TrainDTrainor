using System;
using System.IdentityModel.Tokens.Jwt;
using TrainDTrainorV2.Core.Options;
using TrainDTrainorV2.Core.Security;
using KickStart;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Linq;
using Hangfire;

namespace TrainDTrainorV2.API.Middleware
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder => builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .SetPreflightMaxAge(TimeSpan.FromMinutes(5))
                    .WithExposedHeaders("ETag")
                );
            });
        }
        public static void ConfigureKickStart(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.KickStart(c => c
                .IncludeAssemblyFor<ConfigurationServiceModule>()
                
                //.IncludeAssemblyFor<DataServiceModule>()
                .IncludeAssemblyFor<Startup>()
                .Data(ConfigurationServiceModule.ConfigurationKey, configuration)
                .Data("hostProcess", "web")
                .UseAutoMapper()
                .UseStartupTask()
            );            
        }
        public static void ConfigureAuthentication(this IServiceCollection services, ServiceProvider provider)
        {
            var principalOptions = provider.GetService<IOptions<PrincipalConfiguration>>();
            var hostingOptions = provider.GetService<IOptions<HostingConfiguration>>();


            // disable claim mapping
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();

            var key = Base64UrlTextEncoder.Decode(principalOptions.Value.AudienceSecret);
            var securityKey = new SymmetricSecurityKey(key);

            var validationParameters = new TokenValidationParameters
            {
                NameClaimType = TokenConstants.Claims.Name,
                RoleClaimType = TokenConstants.Claims.Role,
                ValidIssuer = hostingOptions.Value.ClientDomain,
                ValidAudience = principalOptions.Value.AudienceId,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
            };


            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = validationParameters;
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = true;

                });
           
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                             new Info
                             {
                                 Title = "Train of Trainor - V1",
                                 Version = "v1",
                                 Description = "Train of Trainor Web Api Documentation",
                                 TermsOfService = "....",
                                 Contact = new Contact
                                 {
                                     Name = "Moises B. Bas",
                                     Email = "moises.bas@mobadrah.ae"
                                 },
                                 License = new License
                                 {
                                     Name = "Mobadrah Training 2.0",
                                     Url = "www.mobadrah.ae"
                                 }
                             });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Authorization format : Bearer {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                { "Bearer", Enumerable.Empty<string>() },
            });
                c.OperationFilter<FormFileOperationFilter>();
                c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
                c.EnableAnnotations();
            });
        }
        public static void ConfigureMvc(this IServiceCollection services)
        {
            services
               .AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               .AddJsonOptions(o =>
               {
                   o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                   o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               });
        }
    }
}
