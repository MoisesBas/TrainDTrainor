using System.Collections.Generic;
using TrainDTrainorV2.Core.Options;
using KickStart.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;

namespace TrainDTrainorV2.Core.Data
{
    public class DataServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            data.TryGetValue(ConfigurationServiceModule.ConfigurationKey, out var configurationData);
            if (!(configurationData is IConfiguration configuration))
                return;
            var connectionString = configuration.GetConnectionString("TrainDTrainor");
            //services.AddHangfire(options => options.UseSqlServerStorage(connectionString));
            services.AddDbContext<TrainDTrainorContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<DbContext>(s => s.GetRequiredService<TrainDTrainorContext>());
            
        }
    }
}
