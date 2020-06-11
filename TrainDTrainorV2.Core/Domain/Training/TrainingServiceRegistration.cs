using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.Core.Domain.Training.Models;
using TrainDTrainorV2.Core.Domain.Training.Commands;
using TrainDTrainorV2.Core.Domain.Training.Handlers;

namespace TrainDTrainorV2.Core.Domain.Training
{
    public class TrainingServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.Training, TrainingReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.Training, TrainingReadModel, TrainingCreateModel, TrainingUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<TrainingDetailCommand, TrainingDetailReadModel>, TrainingDetailCommandHandler>();
        }
    }
}
