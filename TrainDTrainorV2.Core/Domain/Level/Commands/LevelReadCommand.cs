using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Domain.Level.Models;

namespace TrainDTrainorV2.Core.Domain.Level.Commands
{
    public class LevelReadCommand : IRequest<LevelReadModel>
    {
        public LevelReadCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
