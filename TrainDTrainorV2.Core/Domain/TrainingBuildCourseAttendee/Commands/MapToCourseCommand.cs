using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Domain.Payment.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Commands
{   
    public class MapToCourseCommand<TUpdateModel> : IRequest<EntitySingleResult<TrainingBuildCoursesAttendeeReadModel>>
    {
        public MapToCourseCommand(TUpdateModel model, Guid id)
        {
            Course = model;             
            Id = id;
        }
        public Guid Id { get; set; }
        public TUpdateModel Course { get; set; }       
    }
}
