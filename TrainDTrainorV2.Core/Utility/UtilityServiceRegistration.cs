using System;
using System.Collections.Generic;
using System.Text;
using KickStart.DependencyInjection;
using Microsoft.ApplicationInsights;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TrainDTrainorV2.Core.Utility
{
    public class UtilityServiceRegistration : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.AddSingleton<IMetricCollectorFactory>(x=> new MetricCollectorFactory(new TelemetryClient()));
        }
    }
}
