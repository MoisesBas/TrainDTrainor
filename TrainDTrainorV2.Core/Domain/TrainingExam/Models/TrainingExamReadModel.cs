using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingExam.Models
{
    public class TrainingExamReadModel: EntityReadModel<Guid>
    {
        public string Question { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? TrainingId { get; set; }
        public int QuestionType { get; set; }
    }
}
