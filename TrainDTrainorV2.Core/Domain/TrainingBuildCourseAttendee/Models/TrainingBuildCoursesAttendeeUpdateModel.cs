using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models
{
    public class TrainingBuildCoursesAttendeeUpdateModel: EntityUpdateModel
    {
        public Guid AttendeeId { get; set; }
        public Guid CourseId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }        
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public Guid? TrainingBuildCourseParentId { get; set; }
    }
}
