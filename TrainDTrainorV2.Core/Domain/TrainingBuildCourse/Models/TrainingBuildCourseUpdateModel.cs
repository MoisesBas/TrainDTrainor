using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingBuildCourse.Models
{
    public class TrainingBuildCourseUpdateModel: EntityUpdateModel
    {
       
        public Guid? CourseId { get; set; }
        public Guid? LevelId { get; set; }
        public Guid? QuestionId { get; set; }        
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }        
    }
}
