using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Commands
{
    public class TrainingBuildCourseDetailCommand : IRequest<TrainingBuildCourseReadModel>
    {
        public TrainingBuildCourseDetailCommand(Guid id)
        {
        }
        public Guid Id { get; set; }
    }
}
