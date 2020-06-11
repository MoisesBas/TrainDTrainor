using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.Core.Domain.Training.Models;

namespace TrainDTrainorV2.Core.Domain.Training.Commands
{
    public class TrainingDetailCommand: IRequest<TrainingDetailReadModel>
    {
        public TrainingDetailCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
