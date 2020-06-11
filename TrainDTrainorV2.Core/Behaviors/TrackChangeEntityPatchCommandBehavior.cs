using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.CommandQuery.Commands;

namespace TrainDTrainorV2.Core.Behaviors
{
    public class TrackChangeEntityPatchCommandBehavior<TKey, TEntity, TReadModel> : PipelineBehaviorBase<EntityPatchCommand<TKey, TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
    {
        public TrackChangeEntityPatchCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }

        protected override async Task<TReadModel> Process(EntityPatchCommand<TKey, TEntity, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }

    }
}
