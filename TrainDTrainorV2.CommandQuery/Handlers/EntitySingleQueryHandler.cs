using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using TrainDTrainorV2.CommandQuery.Extensions;
using TrainDTrainorV2.CommandQuery.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TrainDTrainorV2.CommandQuery.Handlers
{
    public class EntitySingleQueryHandler<TEntity, TReadModel> : RequestHandlerBase<EntitySingleQuery<TEntity, TReadModel>, EntitySingleResult<TReadModel>>
        where TEntity : class
    {
        private static readonly Lazy<TReadModel> _emptyList = new Lazy<TReadModel>();

        private readonly DbContext _context;
        private readonly IConfigurationProvider _configurationProvider;

        public EntitySingleQueryHandler(ILoggerFactory loggerFactory, DbContext context, IConfigurationProvider configurationProvider) : base(loggerFactory)
        {
            _context = context;
            _configurationProvider = configurationProvider;
        }

        protected override async Task<EntitySingleResult<TReadModel>> ProcessAsync(EntitySingleQuery<TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            var entityQuery = message.Query;

            // build query from filter
            var query = entityQuery.Query.Filter(_context.Set<TEntity>().AsNoTracking());
            if (!string.IsNullOrEmpty(entityQuery.Query.IncludeProperties)){
                foreach (var includeProperty in entityQuery.Query.IncludeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            
            // get total for query
            var total = await query
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            // short circuit if total is zero
            if (total == 0)
                return new EntitySingleResult<TReadModel> { Data = _emptyList.Value };

            // page the query and convert to read model
            var result = await query               
                .ProjectTo<TReadModel>(_configurationProvider)
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);

            return new EntitySingleResult<TReadModel>
            {                
                Data = result
            };
        }



    }
}