using System;
using System.Collections.Generic;
using System.Text;
using KickStart.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TrainDTrainorV2.Core.Services
{
    public class RegisterServiceModule : IDependencyInjectionRegistration
    {
        public void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddSingleton<IEmailTemplateService, EmailTemplateService>();
            services.TryAddTransient<IAuthenticationHelper, AuthenticationHelper>();
            services.TryAddTransient<ISMSTemplateService, SMSTemplateService>();
            services.TryAddTransient<IGridFsService, GridFsService>();
        }
    }
}
