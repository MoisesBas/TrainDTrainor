using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.ExamResult.Models
{
    public class ExamResultCreateModel: EntityCreateModel<Guid>
    {
        public Guid UserId { get; set; }
        public Guid QuestionId { get; set; }
        public Guid CourseId { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
