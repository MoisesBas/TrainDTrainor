using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo.Commands
{
  
    public class LevelBestVideoGetCommand<TKey> : EntityIdentifierCommand<TKey, LevelBestVideoReadModel>
    {
        public LevelBestVideoGetCommand(TKey id) : base(id)
        {
        }
    }
}
