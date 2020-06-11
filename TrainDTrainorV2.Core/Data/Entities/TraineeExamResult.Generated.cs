using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class TraineeExamResult 
    {
        public TraineeExamResult()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid CourseId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public virtual TrainingCourse Course { get; set; }
        public virtual TrainingExam Question { get; set; }
        public virtual User User { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
    }
}
