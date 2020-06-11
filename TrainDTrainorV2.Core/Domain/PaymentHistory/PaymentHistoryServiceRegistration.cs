using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;

using TrainDTrainorV2.Core.Domain.PaymentHistory.Models;

namespace TrainDTrainorV2.Core.Domain.PaymentHistory
{
    public class PaymentHistoryServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.PaymentTransactionHistory, PaymentHistoryReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.PaymentTransactionHistory, PaymentHistoryReadModel, PaymentHistoryCreateModel, PaymentHistoryUpdateModel>(services);            
            
            
            

        }
    }
}
