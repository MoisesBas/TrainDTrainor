using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.Education.Models;

namespace TrainDTrainorV2.Core.Domain.Education.Commands
{
    public class EducationReadCommand<TEducation> : IRequest<EntityListResult<EducationReadModel>>
    {
        public EducationReadCommand(EntityQuery<TEducation> entityQuery)
        {
            EntityQuery = entityQuery;
        }
        public EntityQuery<TEducation> EntityQuery { get; set; }
    }
}
