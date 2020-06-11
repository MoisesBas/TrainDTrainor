using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
public partial   class CommitteeQuestion
    {
        public CommitteeQuestion()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            TraineeQuestionEvaluations = new HashSet<CommitteeQuestionEvaluation>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuestionType { get; set; }       
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual ICollection<CommitteeQuestionEvaluation> TraineeQuestionEvaluations { get; set; }

    }
}
