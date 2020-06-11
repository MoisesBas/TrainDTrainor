using System;
using System.Collections.Generic;
using TrainDTrainorV2.Core.Domain.Authentication.Commands;
using TrainDTrainorV2.Core.Domain.Authentication.Handlers;
using TrainDTrainorV2.Core.Security;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace TrainDTrainorV2.Core.Domain.Authentication
{
    public class AuthenticationServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddTransient<IRequestHandler<AuthenticateCommand, TokenResponse>, AuthenticateCommandHandler>();
        }
    }
}
