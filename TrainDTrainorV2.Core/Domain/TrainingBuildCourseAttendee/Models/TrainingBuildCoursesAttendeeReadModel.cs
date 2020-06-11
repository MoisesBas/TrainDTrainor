using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.Course.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourseAttendee.Models
{
    public class TrainingBuildCoursesAttendeeReadModel: EntityReadModel<Guid>
    {
        public Guid AttendeeId { get; set; }
        public Guid CourseId { get; set; }
        public string Course { get; set; }
        public string DisplayName { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public CourseReadModel  Courses { get; set; }
        public Guid? TrainingBuildCourseParentId { get; set; }
    }
}
