using System;
using System.Collections.Generic;
using AutoMapper;
using KickStart.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace TrainDTrainorV2.Core.Domain
{
    public class MapperServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddSingleton(p => Mapper.Instance);
            services.AddSingleton(p => Mapper.Instance.ConfigurationProvider);
        }
    }
}
