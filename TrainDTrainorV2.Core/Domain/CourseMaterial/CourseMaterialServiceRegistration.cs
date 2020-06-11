using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Commands;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Handlers;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Models;

namespace TrainDTrainorV2.Core.Domain.CourseMaterial
{
    public class CourseMaterialServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.CourseMaterial, CourseMaterialReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.CourseMaterial, CourseMaterialReadModel, CourseMaterialCreateModel, CourseMaterialUpdateModel>(services);

            RegisterEntityQuery<Guid, Data.Entities.LevelVideoPic, CourseMaterialReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.LevelVideoPic, CourseMaterialReadModel, object, object>(services);
            services.TryAddTransient<IRequestHandler<CourseMaterialCommand<CourseMaterialCreateModel>, CourseMaterialReadModel>, CourseMaterialCommandHandler>(); services.AddTransient<IPipelineBehavior<CourseMaterialCommand<CourseMaterialCreateModel>, CourseMaterialReadModel>, ValidateEntityModelCommandBehavior<CourseMaterialCreateModel, CourseMaterialReadModel>>();
            services.TryAddTransient<IRequestHandler<CourseMaterialGetCommand<Guid>, CourseMaterialReadModel>, CourseMaterialGetCommandHandler>();
        }
    }
}
