using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class EmailDeliveryExtensions
    {

        
        public static TrainDTrainorV2.Core.Data.Entities.EmailDelivery GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.EmailDelivery> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.EmailDelivery>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(e => e.Id == id);
        }

       
        public static Task<TrainDTrainorV2.Core.Data.Entities.EmailDelivery> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.EmailDelivery> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.EmailDelivery>;
            if (dbSet != null)
                return dbSet.FindAsync(id);
            return queryable.FirstOrDefaultAsync(e => e.Id == id);
        }

        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.EmailDelivery> ByIsProcessingIsDeliveredNextAttempt(this IQueryable<TrainDTrainorV2.Core.Data.Entities.EmailDelivery> queryable, bool isProcessing, bool isDelivered, DateTimeOffset? nextAttempt)
        {
            return queryable.Where(e => e.IsProcessing == isProcessing
                && e.IsDelivered == isDelivered
                && (e.NextAttempt == nextAttempt || (nextAttempt == null && e.NextAttempt == null)));
        }       
       
    }
}
