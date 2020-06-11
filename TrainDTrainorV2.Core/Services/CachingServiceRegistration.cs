using KickStart.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Services.Caching;
using TrainDTrainorV2.Core.Services.Caching.Providers;

namespace TrainDTrainorV2.Core.Services
{
    public class CachingServiceRegistration : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddOptions();
            services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MemoryCache>());
            services.TryAdd(ServiceDescriptor.Singleton<ICacheProvider, MemoryCacheProvider>());
            services.TryAdd(ServiceDescriptor.Singleton<IAppCache, CachingService>());
        }
    }
}
