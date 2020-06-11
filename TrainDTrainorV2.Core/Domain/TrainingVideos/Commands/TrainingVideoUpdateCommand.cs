using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingVideos.Commands
{
    public class TrainingVideoUpdateCommand<TUpdateModel, TKey> : EntityUpdateCommand<TKey, TrainingVideo, TUpdateModel, TrainingVideoReadModel>
    {
        public TrainingVideoUpdateCommand(TKey id, TUpdateModel model, IPrincipal principal,
            UserAgentModel userAgent) : base(id, model, principal)
        {
            TrainingVideo = model;
            Id = id;
            UserAgent = userAgent;
        }
        public TUpdateModel TrainingVideo { get; set; }
        public UserAgentModel UserAgent { get; set; }
    }
}
