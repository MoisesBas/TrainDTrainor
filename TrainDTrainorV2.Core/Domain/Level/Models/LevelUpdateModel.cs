using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Level.Models
{
    public class LevelUpdateModel: EntityUpdateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid TrainingId { get; set; }
    }
}
