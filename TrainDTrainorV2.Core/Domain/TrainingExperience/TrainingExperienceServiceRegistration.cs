using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Commands;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Handlers;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExperience
{
    public class TrainingExperienceServiceRegistration : DomainServiceRegistrationBase
    {
        public override void Register(IServiceCollection services, IDictionary<string, object> data)
        {
            RegisterEntityQuery<Guid, Data.Entities.TrainingExperience, TrainingExperienceReadModel>(services);
            RegisterEntityCommand<Guid, Data.Entities.TrainingExperience, TrainingExperienceReadModel, TrainingExperienceCreatedModel, TrainingExperienceUpdatedModel>(services);
            services.TryAddTransient<IRequestHandler<TrainingExperienceReadCommand<Core.Data.Entities.TrainingExperience>, EntityListResult<TrainingExperienceReadModel>>, TrainingExperienceReadCommandHandlers>();
        }
    }
}
