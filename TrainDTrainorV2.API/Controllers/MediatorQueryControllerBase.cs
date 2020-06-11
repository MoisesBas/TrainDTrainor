using System;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Queries;
using MediatR;
using TrainDTrainorV2.Core.Services;
using Microsoft.Extensions.Caching.Memory;
using TrainDTrainorV2.Core.Services.Caching;

namespace TrainDTrainorV2.API.Controllers
{
    public abstract class MediatorQueryControllerBase<TKey, TEntity, TReadModel> : MediatorControllerBase
        where TEntity : class, new()
    {
        protected MediatorQueryControllerBase(IMediator mediator) 
            : base(mediator)
        {
        }
        protected MediatorQueryControllerBase(IMediator mediator, IAppCache cache)
            : base(mediator,cache)
        {
        }
        protected MediatorQueryControllerBase(IMediator mediator,
            IGridFsService gridFsService) : base(mediator,gridFsService)
        {
        }

        protected virtual async Task<TReadModel> GetQuery(TKey id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityIdentifierQuery<TKey, TEntity, TReadModel>(id, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }

        protected virtual async Task<EntityListResult<TReadModel>> ListQuery(EntityQuery<TEntity> entityQuery, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntityListQuery<TEntity, TReadModel>(entityQuery, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return result;
        }
        protected virtual async Task<EntitySingleResult<TReadModel>> FirstOrDefaultQuery(SingleQuery<TEntity> entityQuery, CancellationToken cancellationToken = default(CancellationToken))
        {
            var command = new EntitySingleQuery<TEntity, TReadModel>(entityQuery, User);
            var result = await Mediator.Send(command, cancellationToken).ConfigureAwait(false);

            return result;
        }
    }
}