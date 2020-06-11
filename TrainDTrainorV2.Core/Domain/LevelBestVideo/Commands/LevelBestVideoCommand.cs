using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.LevelBestVideo;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo.Commands
{
  
    public class LevelBestVideoCommand<TCreateModel> : EntityCreateCommand<LevelVideo, TCreateModel, LevelBestVideoReadModel>
    {
        public LevelBestVideoCommand(TCreateModel model,UserAgentModel userAgent) : base(model, null)
        {
            Model = model;
            UserAgentModel = userAgent;
        }
        public UserAgentModel UserAgentModel { get; set; }
    }
}
