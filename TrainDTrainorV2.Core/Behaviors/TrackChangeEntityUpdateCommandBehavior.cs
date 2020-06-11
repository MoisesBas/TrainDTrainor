using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Behaviors;
using TrainDTrainorV2.CommandQuery.Commands;

namespace TrainDTrainorV2.Core.Behaviors
{
    public class TrackChangeEntityUpdateCommandBehavior<TKey, TEntity, TUpdateModel, TReadModel> : PipelineBehaviorBase<EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel>, TReadModel>
        where TEntity : class, new()
    {
        public TrackChangeEntityUpdateCommandBehavior(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }
        protected override async Task<TReadModel> Process(EntityUpdateCommand<TKey, TEntity, TUpdateModel, TReadModel> request, CancellationToken cancellationToken, RequestHandlerDelegate<TReadModel> next)
        {
            // continue pipeline
            return await next().ConfigureAwait(false);
        }
    }
}
