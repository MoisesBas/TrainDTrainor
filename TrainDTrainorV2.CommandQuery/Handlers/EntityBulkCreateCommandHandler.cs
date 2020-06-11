using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TrainDTrainorV2.CommandQuery.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using EFCore.BulkExtensions;
using System.Linq;

namespace TrainDTrainorV2.CommandQuery.Handlers
{
    public class EntityBulkCreateCommandHandler<TEntity, TCreateModel, TReadModel> : RequestHandlerBase<EntityBulkCreateCommand<TEntity, TCreateModel, TReadModel>, IEnumerable<TReadModel>>
        where TEntity : class, new()
    {
        private readonly DbContext _context;
        private readonly IMapper _mapper;

        public EntityBulkCreateCommandHandler(ILoggerFactory loggerFactory, DbContext context, IMapper mapper) : base(loggerFactory)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task<IEnumerable<TReadModel>> ProcessAsync(EntityBulkCreateCommand<TEntity, TCreateModel, TReadModel> message, CancellationToken cancellationToken)
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