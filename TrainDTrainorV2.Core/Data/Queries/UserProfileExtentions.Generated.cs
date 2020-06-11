using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class UserProfileExtentions
    {
        
        public static TrainDTrainorV2.Core.Data.Entities.UserProfile GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfile> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.UserProfile>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(i => i.Id == id);
        }

        


        public static Task<TrainDTrainorV2.Core.Data.Entities.UserProfile> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfile> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.UserProfile>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(i => i.Id == id);
        }        
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfile> ByEmailAddress(this IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfile> queryable, string emailAddress)
        {
            return queryable.Where(i => i.EmailAddress == emailAddress);
        }
                
        public static Task<TrainDTrainorV2.Core.Data.Entities.UserProfile> ByUserId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfile> queryable, Guid? userId)
        {
            return queryable.FirstOrDefaultAsync(i => i.UserId == userId);
        }
    }
}
