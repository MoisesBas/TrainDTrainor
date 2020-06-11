using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Commands;
using TrainDTrainorV2.Core.Domain.TrainingVideos.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingVideos.Handlers
{
    public class TrainingVideoGetCommandHandler : RequestHandlerBase<TrainingVideoGetCommand<Guid>, TrainingVideoReadModel>
    {
        private readonly IMediator Mediator;       
        public TrainingVideoGetCommandHandler(ILoggerFactory loggerFactory,
            IMediator mediator) : base(loggerFactory)
        {
            Mediator = mediator;
        }

        protected override async Task<TrainingVideoReadModel> ProcessAsync(TrainingVideoGetCommand<Guid> message,
            CancellationToken cancellationToken)
        {
            var search = Query<TrainingVideoPic>.Create(x => x.Stream_id == message.Id);
            var query = new SingleQuery<TrainingVideoPic>(search);
            var command = new EntitySingleQuery<TrainingVideoPic, TrainingVideoReadModel>(query);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.Data;
        }
    }
}
