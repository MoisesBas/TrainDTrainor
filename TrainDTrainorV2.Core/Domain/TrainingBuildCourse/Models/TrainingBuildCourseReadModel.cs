using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.Course.Models;
using TrainDTrainorV2.Core.Domain.Level.Models;
using TrainDTrainorV2.Core.Domain.LevelQuestion.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models
{
    public class TrainingBuildCourseReadModel: EntityReadModel<Guid>
    {         
        public Guid? CourseId { get; set; }
        public Guid? LevelId { get; set; }
        public Guid? QuestionId { get; set; }
        public CourseReadModel Course { get; set; }
        public LevelQuestionReadModel Question { get; set; }
        public LevelReadModel Level { get; set; }
        public bool? IsDeleted { get; set; }               
    }
}
