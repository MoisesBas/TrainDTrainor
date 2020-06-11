using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models
{
    public class TrainingBuildCoursesAttendeeCreatedModel: EntityCreateModel<Guid>
    {
        public Guid AttendeeId { get; set; }
        public Guid CourseId { get; set; }
        public Guid? TrainingBuildCourseParentId { get; set; }

    }
}
