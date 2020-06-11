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
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Commands;
using TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Models;

namespace TrainDTrainorV2.Core.Domain.TrainingAttendeeEvaluationVideo.Handlers
{
   

    public class EvaluationVideoGetCommandHandler : RequestHandlerBase<EvaluationVideoGetCommand<Guid>, EvaluationVideoReadModel>
    {
        private readonly IMediator Mediator;
        public EvaluationVideoGetCommandHandler(ILoggerFactory loggerFactory,
            IMediator mediator) : base(loggerFactory)
        {
            Mediator = mediator;
        }

        protected override async Task<EvaluationVideoReadModel> ProcessAsync(EvaluationVideoGetCommand<Guid> message,
            CancellationToken cancellationToken)
        {
            var search = Query<EvaluationVideoPic>.Create(x => x.Stream_id == message.Id);
            var query = new SingleQuery<EvaluationVideoPic>(search);
            var command = new EntitySingleQuery<EvaluationVideoPic, EvaluationVideoReadModel>(query);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.Data;

        }
    }
}
