using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Course.Models;

namespace TrainDTrainorV2.Core.Domain.Course.Commands
{
    public class CourseReadCommand : IRequest<CourseReadModel>
    {
        public CourseReadCommand(Guid traineeId)
        {
            TraineeId = traineeId;
        }
        public Guid TraineeId { get; set; }
    }
}
