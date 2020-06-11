using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Course.Models;

namespace TrainDTrainorV2.Core.Domain.Course.Commands
{
    public class CourseDetailReadCommand: IRequest<CourseReadModel>
    {
        public CourseDetailReadCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
