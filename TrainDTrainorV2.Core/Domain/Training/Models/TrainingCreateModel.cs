using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Training.Models
{
    public class TrainingCreateModel: EntityCreateModel<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
    }
}
