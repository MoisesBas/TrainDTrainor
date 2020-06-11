using System;
using System.Collections.Generic;
using TrainDTrainorV2.Core.Services.PayFort.Command;
using TrainDTrainorV2.Core.Services.PayFort.Handler;
using TrainDTrainorV2.Core.Security;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.Core.Domain;

namespace TrainDTrainorV2.Core.Services.PayFort
{
    public class PayFortServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            services.TryAddTransient<IRequestHandler<PayFortCommand, PayFortResponse>, PayFortCommandHandler>();
        }
    }
}
