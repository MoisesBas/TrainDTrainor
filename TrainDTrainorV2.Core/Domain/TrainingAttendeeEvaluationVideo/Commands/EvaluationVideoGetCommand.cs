using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Commands
{
        public class EvaluationVideoGetCommand<TKey> : EntityIdentifierCommand<TKey, EvaluationVideoReadModel>
    {
        public EvaluationVideoGetCommand(TKey id) : base(id)
        {
        }
    }
}
