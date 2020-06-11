using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.Level.Models;

namespace TrainDTrainorV2.Core.Domain.Level.Commands
{
    public class LevelCourseReadCommand<TTrainingBuildCourse> : IRequest<EntityListResult<LevelReadModel>>
    {
        public LevelCourseReadCommand(EntityQuery<TTrainingBuildCourse> entityQuery, Guid courseId)
        {
            EntityQuery = entityQuery;
            CourseId = courseId;
        }
        public Guid CourseId { get; set; }
        public EntityQuery<TTrainingBuildCourse> EntityQuery { get; set; }
    }
}
