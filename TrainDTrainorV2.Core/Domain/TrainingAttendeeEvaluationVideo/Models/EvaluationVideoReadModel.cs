using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models
{
   public class EvaluationVideoReadModel: EntityReadModel<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid TrainingBuildCourseAttendeeId { get; set; }
        public Guid CourseLevelId { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public Guid FileId { get; set; }
    }
}
