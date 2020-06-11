using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class TrainingBuildCourse
    {
        public TrainingBuildCourse()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            
        }
        public Guid Id { get; set; }
        public Guid? CourseId { get; set; }
        public Guid? LevelId { get; set; }
        public Guid? QuestionId { get; set; }
        public virtual TrainingCourse Course { get; set; }
        public virtual LevelQuestion Question { get; set; }
        public virtual Level Level { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }       
    }
}
