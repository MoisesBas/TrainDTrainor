using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.TrainingExperience.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExperience.Commands
{
    public class TrainingExperienceReadCommand<TExperience>: IRequest<EntityListResult<TrainingExperienceReadModel>>
    {
        public TrainingExperienceReadCommand(EntityQuery<TExperience> entityQuery)
        {
            EntityQuery = entityQuery;
        }
        public EntityQuery<TExperience> EntityQuery { get; set; }
    }
    
}
