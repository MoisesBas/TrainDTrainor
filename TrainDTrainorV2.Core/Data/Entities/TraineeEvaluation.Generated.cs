using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class TraineeEvaluation
    {
        public TraineeEvaluation()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }
        public Guid Id { get; set; }
        public Guid? TrainingCourseAttendeeId { get; set; }      
        public Guid? EvaluatorId { get; set; }
        public Guid? TrainingBuildCourseId { get; set; }        
        public int Evaluation { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }             
        public virtual User Evaluator { get; set; }
        public virtual TrainingBuildCourse TrainingBuildCourse { get; set; }
        public virtual TrainingBuildCourseAttendee TrainingCourseAttendee { get; set; }
    }
}
