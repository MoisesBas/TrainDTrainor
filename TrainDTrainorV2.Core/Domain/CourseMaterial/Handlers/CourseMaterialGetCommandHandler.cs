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
using TrainDTrainorV2.Core.Domain.CourseMaterial.Commands;
using TrainDTrainorV2.Core.Domain.CourseMaterial.Models;

namespace TrainDTrainorV2.Core.Domain.CourseMaterial.Handlers
{
   

    public class CourseMaterialGetCommandHandler : RequestHandlerBase<CourseMaterialGetCommand<Guid>, CourseMaterialReadModel>
    {
        private readonly IMediator Mediator;
        public CourseMaterialGetCommandHandler(ILoggerFactory loggerFactory,
            IMediator mediator) : base(loggerFactory)
        {
            Mediator = mediator;
        }

        protected override async Task<CourseMaterialReadModel> ProcessAsync(CourseMaterialGetCommand<Guid> message,
            CancellationToken cancellationToken)
        {
            var search = Query<CourseMaterialPic>.Create(x => x.Stream_id == message.Id);
            var query = new SingleQuery<CourseMaterialPic>(search);
            var command = new EntitySingleQuery<CourseMaterialPic, CourseMaterialReadModel>(query);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result.Data;

        }
    }
}
