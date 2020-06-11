using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Helper;

namespace TrainDTrainorV2.CommandQuery.Queries
{
    public class SingleQuery<TEntity>
    {        
        public SingleQuery(IQuery<TEntity> query)
        {
            Query = query;
        }
        
        public IQuery<TEntity> Query { get; set; }
        public EntityFilter Filter { get; set; }
    }
}
