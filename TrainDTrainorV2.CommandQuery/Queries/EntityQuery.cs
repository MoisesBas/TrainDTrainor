using System;
using System.Collections.Generic;
using TrainDTrainorV2.CommandQuery.Helper;

namespace TrainDTrainorV2.CommandQuery.Queries
{
    public class EntityQuery<TEntity>
    {
        public EntityQuery()
        {
            Page = 1;
            PageSize = 20;

        }

        public EntityQuery(IQuery<TEntity> query, int page, int pageSize, string sort)
        {
            Query = query;
            Page = page;
            PageSize = pageSize;

            var entitySort = EntitySort.Parse(sort);
            if (entitySort == null)
                return;

            Sort = new[] { entitySort };
        }       

        public int Page { get; set; }

        public int PageSize { get; set; }
        public IQuery<TEntity> Query { get; set; }

        public IEnumerable<EntitySort> Sort { get; set; }        
    }
}