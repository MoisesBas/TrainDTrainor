using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Queries;

namespace TrainDTrainorV2.CommandQuery.Handlers
{  
    public class EntitySingleDeleteCommandHandler<TEntity, TReadModel> : RequestHandlerBase<EntityDeleteQuery<TEntity, TReadModel>, bool>
        where TEntity : class
    {
        private static readonly Lazy<TReadModel> _emptyList = new Lazy<TReadModel>();

        private readonly DbContext _context;
        private readonly IConfigurationProvider _configurationProvider;

        public EntitySingleDeleteCommandHandler(ILoggerFactory loggerFactory, DbContext context, IConfigurationProvider configurationProvider) : base(loggerFactory)
        {
            _context = context;
            _configurationProvider = configurationProvider;
        }

        protected override async Task<bool> ProcessAsync(EntityDeleteQuery<TEntity, TReadModel> message, CancellationToken cancellationToken)
        {
            var entityQuery = message.Query;
            var dbSet = _context.Set<TEntity>();
            // build query from filter
            var query = entityQuery.Query.Filter(dbSet);
            if (!string.IsNullOrEmpty(entityQuery.Query.IncludeProperties))
            {
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
                throw new Exception("Unable to find records.,");

            // page the query and convert to read model
            var result = await query
                .FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
            dbSet.Remove(result);
            var output  = await _context
               .SaveChangesAsync(cancellationToken)
               .ConfigureAwait(false);
           
            return output == 1 ? true:false;
          
        }

       



    }
}
