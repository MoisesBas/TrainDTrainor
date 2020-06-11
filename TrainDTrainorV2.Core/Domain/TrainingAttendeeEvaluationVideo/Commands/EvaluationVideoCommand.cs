using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models;
using TrainDTrainorV2.Core.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Commands
{
   public class EvaluationVideoCommand<TCreateModel> : EntityCreateCommand<TraineeEvaluationVideo, TCreateModel, EvaluationVideoReadModel>
    {
        public EvaluationVideoCommand(TCreateModel model, UserAgentModel userAgent) : base(model, null)
        {
            Model = model;
            UserAgentModel = userAgent;
        }
        public UserAgentModel UserAgentModel { get; set; }
    }
}
