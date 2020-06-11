using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;
using TrainDTrainorV2.Core.Domain.LevelQuestion.Models;
using TrainDTrainorV2.Core.Domain.LevelSubject.Models;

namespace TrainDTrainorV2.Core.Domain.Level.Models
{
   public class LevelReadModel: EntityReadModel<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid TrainingId { get; set; }
        public IEnumerable<LevelSubjectReadModel> Subjects { get; set; }
        public IEnumerable<LevelQuestionReadModel> Questions { get; set; }
        public IEnumerable<LevelQuestionReadModel> Strengths { get; set; }
        public IEnumerable<LevelQuestionReadModel> Improvements { get; set; }
        public IEnumerable<LevelBestVideoReadModel> Videos { get; set; }
    }
}
