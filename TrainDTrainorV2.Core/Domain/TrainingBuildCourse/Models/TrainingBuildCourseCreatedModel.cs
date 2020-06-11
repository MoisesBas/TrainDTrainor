using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models
{
    public class TrainingBuildCourseCreatedModel : EntityCreateModel<Guid>
    {
        public Guid? CourseId { get; set; }
        public Guid? LevelId { get; set; }
        public Guid? QuestionId { get; set; }
    }
}
