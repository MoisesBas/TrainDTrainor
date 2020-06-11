using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class UserExtensions
    {

    
        public static TrainDTrainorV2.Core.Data.Entities.User GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.User> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.User>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }
      
        public static Task<TrainDTrainorV2.Core.Data.Entities.User> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.User> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.User>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(u => u.Id == id);
        }
       
        public static TrainDTrainorV2.Core.Data.Entities.User GetByEmailAddress(this IQueryable<TrainDTrainorV2.Core.Data.Entities.User> queryable, string emailAddress)
        {
            return queryable.FirstOrDefault(u => u.EmailAddress == emailAddress);
        }
        
        public static Task<TrainDTrainorV2.Core.Data.Entities.User> GetByEmailAddressAsync(this IQueryable<TrainDTrainorV2.Core.Data.Entities.User> queryable, string emailAddress)
        {
            return queryable.FirstOrDefaultAsync(u => u.EmailAddress == emailAddress);
        }       
       
    }
}
