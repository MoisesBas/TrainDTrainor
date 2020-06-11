using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;

namespace TrainDTrainorV2.Core.Domain.Training.Models
{
   public class TrainingDetailReadModel: EntityReadModel<Guid>
    {
        public TrainingDetailReadModel()
        {
            Videos = new List<TrainingVideoReadModel>();
            Steps = new List<LevelModel>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public TrainingVideoReadModel LatestVideo { get; set; }
        public IEnumerable<TrainingVideoReadModel> Videos { get; set; }
        public IEnumerable<LevelModel> Steps { get; set; }
    }
}
