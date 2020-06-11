using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models;

namespace TrainDTrainorV2.Core.Domain.Course.Models
{
    public class CourseDetailReadModel: EntityReadModel<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Objectives { get; set; }
        public Guid? TrainorId { get; set; }
        public Guid? TrainingId { get; set; }
        public short CalendarYear { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string LocationMap { get; set; }
        public string Address { get; set; }
        public int MaxAttendee { get; set; }
        public IEnumerable<TrainingBuildCourseReadModel> BuildCourses { get; set; }
    }
}
