using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingVideos.Commands
{
    public class TrainingVideoGetCommand<TKey> : EntityIdentifierCommand<TKey, TrainingVideoReadModel>
    {
        public TrainingVideoGetCommand(TKey id) : base(id)
        {
        }
    }
}
