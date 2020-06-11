using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.Payment.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Handlers;
using TrainDTrainorV2.Core.Domain.Payment.Models;

namespace TrainDTrainorV2.Core.Domain.Payment
{
    public class PaymentHistoryServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.PaymentTransaction, PaymentReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.PaymentTransaction, PaymentReadModel, PaymentCreateModel, PaymentUpdateModel>(services);            
            services.TryAddTransient<IRequestHandler<PaymentApprovalReadCommand<PaymentDetailApproval>, EntityListResult<PaymentDetailApprovalModel>>, PaymentApprovalReadCommandHandler>();
            services.TryAddTransient<IRequestHandler<PaymentApprovalCommand<Guid,PaymentTransaction,PaymentReadModel>,PaymentReadModel>, PaymentApprovalCommandHandler>();
            services.TryAddTransient<IRequestHandler<PaymentCommand, PaymentReadModel>, PaymentCommandHandler>();
            services.TryAddTransient<IRequestHandler<PaymentGetCommand, PaymentReadModel>, PaymentGetCommandHandler>();
            services.TryAddTransient<IRequestHandler<PaymentUpdateCommand<PaymentUpdateModel,Guid>, PaymentReadModel>, PaymentUpdateCommandHandler>();         services.AddTransient<IPipelineBehavior<PaymentUpdateCommand<PaymentUpdateModel,Guid>,PaymentReadModel> ,ValidateEntityModelCommandBehavior <PaymentUpdateModel, PaymentReadModel>>();
            

        }
    }
}
