using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Handlers;
using TrainDTrainorV2.CommandQuery.Helper;
using TrainDTrainorV2.CommandQuery.Queries;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Commands;
using TrainDTrainorV2.Core.Domain.LevelBestVideo.Models;

namespace TrainDTrainorV2.Core.Domain.LevelBestVideo.Handlers
{    
    public class LevelBestVideoGetCommandHandler : RequestHandlerBase<LevelBestVideoGetCommand<Guid>, LevelBestVideoReadModel>
    {
        private readonly IMediator Mediator;
        public LevelBestVideoGetCommandHandler(ILoggerFactory loggerFactory,
            IMediator mediator) : base(loggerFactory)
        {
            Mediator = mediator;
        }

        protected override async Task<LevelBestVideoReadModel> ProcessAsync(LevelBestVideoGetCommand<Guid> message,
            CancellationToken cancellationToken)
        {
            var search = Query<LevelVideoPic>.Create(x => x.Stream_id == message.Id);
            var query = new SingleQuery<LevelVideoPic>(search);
            var command = new EntitySingleQuery<LevelVideoPic, LevelBestVideoReadModel>(query);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.Data;
        }
    }
}
