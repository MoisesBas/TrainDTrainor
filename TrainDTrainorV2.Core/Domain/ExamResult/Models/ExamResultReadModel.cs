using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.TrainingExam.Models;

namespace TrainDTrainorV2.Core.Domain.ExamResult.Models
{
   public class ExamResultReadModel : EntityReadModel<Guid>
    {
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }
        public TrainingExamReadModel Question { get; set; }
        public Guid CourseId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsActive { get; set; }
    }
}
