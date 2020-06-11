using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.Core.Domain.Level.Handlers;
using TrainDTrainorV2.Core.Domain.Level.Models;
using TrainDTrainorV2.Core.Domain.Models;
using TrainDTrainorV2.Core.Domain.Level.Commands;
using System.Collections.Generic;
using System;

namespace TrainDTrainorV2.Core.Domain.Level
{
    public class LevelServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)

        {
            RegisterEntityQuery<Guid, Data.Entities.Level, LevelReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.Level, LevelReadModel, LevelCreateModel, LevelUpdateModel>(services);

            services.TryAddTransient<IRequestHandler<LevelReadCommand, LevelReadModel>, LevelCommandHandler>();
            services.TryAddTransient<IRequestHandler<LevelCourseReadCommand<Data.Entities.TrainingBuildCourse>, CommandQuery.Queries.EntityListResult<LevelReadModel>>, LevelCourseReadCommandHandler>();
        }
    }
}
