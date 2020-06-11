using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class EmailTemplateExtensions
    {

       
        public static TrainDTrainorV2.Core.Data.Entities.EmailTemplate GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.EmailTemplate>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(e => e.Id == id);
        }

        
        public static Task<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.EmailTemplate>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(e => e.Id == id);
        }

       

      
        public static TrainDTrainorV2.Core.Data.Entities.EmailTemplate GetByKeyMember(this IQueryable<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> queryable, string key)
        {
            return queryable.FirstOrDefault(e => e.Key == key);
        }

       
        public static Task<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> GetByKeyMemberAsync(this IQueryable<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> queryable, string key)
        {
            return queryable.FirstOrDefaultAsync(e => e.Key == key);
        }
    }
}
