using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.LevelQuestion.Models
{
  public class LevelQuestionUpdateModel: EntityUpdateModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? LevelId { get; set; }
        public int QuestionType { get; set; }
    }
}
