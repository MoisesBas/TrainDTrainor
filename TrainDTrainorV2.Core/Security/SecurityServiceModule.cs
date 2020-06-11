using System.Collections.Generic;
using KickStart.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TrainDTrainorV2.Core.Security
{
    public class SecurityServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddSingleton<IPasswordHasher>(s => new PasswordHasher());
        }
    }
}
