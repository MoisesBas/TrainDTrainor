using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Commands;

namespace TrainDTrainorV2.CommandQuery.Handlers
{
    public class EntityBulkDeleteCommandHandler<TEntity, TUpdateModel, TReadModel> : RequestHandlerBase<EntityBulkDeleteCommand<TEntity, TUpdateModel, TReadModel>, IEnumerable<TReadModel>>
        where TEntity : class, new()
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public EntityBulkDeleteCommandHandler(ILoggerFactory loggerFactory, DbContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<IEnumerable<TReadModel>> ProcessAsync(EntityBulkDeleteCommand<TEntity, TUpdateModel, TReadModel> message, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<IEnumerable<TEntity>>(message.Model);
            var dbSet = _context
                .Set<TEntity>();

            await dbSet
               .AddRangeAsync(entity, cancellationToken)
                .ConfigureAwait(false);

            await _context
                .SaveChangesAsync(cancellationToken)
                .ConfigureAwait(false);
            var readModel = _mapper.Map<IEnumerable<TReadModel>>(entity);
            return readModel;
        }
    }
}
