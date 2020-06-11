using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Domain.Payment.Handlers;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Commands;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Handlers;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingVideos
{
    public class TrainingVideoServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.TrainingVideo, TrainingVideoReadModel>(services);         
            RegisterEntityCommand<Guid, Data.Entities.TrainingVideo, TrainingVideoReadModel, TrainingVideoCreateModel, TrainingVideoUpdateModel>(services);

            RegisterEntityQuery<Guid, Data.Entities.TrainingVideoPic, TrainingVideoReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TrainingVideoPic, TrainingVideoReadModel, object, object>(services);

            services.TryAddTransient<IRequestHandler<TrainingVideoCommand<TrainingVideoCreateModel>, TrainingVideoReadModel>, TrainingVideoCommandHandler>();
            services.AddTransient<IPipelineBehavior<TrainingVideoCommand<TrainingVideoCreateModel>, TrainingVideoReadModel>, ValidateEntityModelCommandBehavior<TrainingVideoCreateModel, TrainingVideoReadModel>>();

            services.TryAddTransient<IRequestHandler<TrainingVideoUpdateCommand<TrainingVideoUpdateModel, Guid>, TrainingVideoReadModel>, TrainingVideoUpdateCommandHandler>(); services.AddTransient<IPipelineBehavior<TrainingVideoUpdateCommand<TrainingVideoUpdateModel, Guid>, TrainingVideoReadModel>, ValidateEntityModelCommandBehavior<TrainingVideoUpdateModel, TrainingVideoReadModel>>();

            services.TryAddTransient<IRequestHandler<TrainingVideoGetCommand<Guid>,TrainingVideoReadModel>, TrainingVideoGetCommandHandler>();


        }
    }
}
