using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Commands;
using TrainDTrainorV2.CommandQuery.Definitions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TrainDTrainorV2.CommandQuery.Handlers
{
    public class EntityDeleteCommandHandler<TKey, TEntity, TReadModel> : RequestHandlerBase<EntityDeleteCommand<TKey, TEntity, TReadModel>, TReadModel>
        where TEntity : class, new()
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public EntityDeleteCommandHandler(ILoggerFactory loggerFactory, DbContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }


        protected override async Task<TReadModel> ProcessAsync(EntityDeleteCommand<TKey, TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            
            var dbSet = _context
                .Set<TEntity>();

            var keyValue = new object[] { message.Id };

            var entity = await dbSet
                .FindAsync(keyValue, cancellationToken)
                .ConfigureAwait(false);

            if (entity == null)
                return default(TReadModel);
            
                dbSet.Remove(entity);

            await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);

            // convert deleted entity to read model
            var model = _mapper.Map<TReadModel>(entity);

            return model;
        }

    }
}