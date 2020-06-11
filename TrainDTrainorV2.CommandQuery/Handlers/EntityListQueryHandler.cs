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
    public class EntityListQueryHandler<TEntity, TReadModel> : RequestHandlerBase<EntityListQuery<TEntity, TReadModel>, EntityListResult<TReadModel>>
        where TEntity : class
    {
        private static readonly Lazy<IReadOnlyCollection<TReadModel>> _emptyList = new Lazy<IReadOnlyCollection<TReadModel>>(() => new List<TReadModel>().AsReadOnly());

        private readonly DbContext _context;
        private readonly IConfigurationProvider _configurationProvider;

        public EntityListQueryHandler(ILoggerFactory loggerFactory, DbContext context, IConfigurationProvider configurationProvider) : base(loggerFactory)
        {
            _context = context;
            _configurationProvider = configurationProvider;
        }

        protected override async Task<EntityListResult<TReadModel>> ProcessAsync(EntityListQuery<TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            var entityQuery = message.Query;
            var query = entityQuery.Query != null ? entityQuery.Query.Filter(_context.Set<TEntity>().AsNoTracking())
                : _context.Set<TEntity>().AsNoTracking();

            if (entityQuery.Query != null)
            {
                if (!string.IsNullOrEmpty(entityQuery.Query.IncludeProperties))
                {
                    foreach (var includeProperty in entityQuery.Query.IncludeProperties.Split
                        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        query = query.Include(includeProperty);
                    }
                }
            }
            
            var total = await query
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);
           
            if (total == 0)
                return new EntityListResult<TReadModel> { Data = _emptyList.Value };

            // page the query and convert to read model
            var result = await query
                .Sort(entityQuery.Sort)
                .Page(entityQuery.Page, entityQuery.PageSize)
                .ProjectTo<TReadModel>(_configurationProvider)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return new EntityListResult<TReadModel>
            {
                Total = total,
                Data = result.AsReadOnly()
            };
        }



    }
}