using System;
using System.Collections.Generic;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class TrainingExam
    {
        public TrainingExam()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            ExamResults = new HashSet<TraineeExamResult>();
        }
        public Guid Id { get; set; }
        public Guid? TrainingId { get; set; }
        public string Question { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public int QuestionType { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual Training Training { get; set; }
        public virtual ICollection<TraineeExamResult> ExamResults { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
    }
}
