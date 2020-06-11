using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class CommitteeQuestionEvaluation
    {
        public CommitteeQuestionEvaluation()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }
        public Guid Id { get; set; }           
        public Guid CommitteeId { get; set; }
        public Guid TraineeId { get; set; }
        public Guid? BuildCourseAttendeeId { get; set; }   
        public Guid? CommitteeQuestionId { get; set; }
        public int Evaluation { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }             
        //public virtual User Committee { get; set; }
        //public virtual User Trainee { get; set; }
        public virtual TrainingBuildCourseAttendee TrainingCourseAttendee { get; set; }
        public virtual CommitteeQuestion CommitteeQuestion { get; set; }
    }
}
