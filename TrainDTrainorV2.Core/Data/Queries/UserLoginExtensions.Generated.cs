using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class UserLoginExtensions
    {

        public static TrainDTrainorV2.Core.Data.Entities.UserLogin GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.UserLogin> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.UserLogin>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }
       
        public static Task<TrainDTrainorV2.Core.Data.Entities.UserLogin> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.UserLogin> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.UserLogin>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(u => u.Id == id);
        }

        
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.UserLogin> ByEmailAddress(this IQueryable<TrainDTrainorV2.Core.Data.Entities.UserLogin> queryable, string emailAddress)
        {
            return queryable.Where(u => u.EmailAddress == emailAddress);
        }

        
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.UserLogin> ByUserId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.UserLogin> queryable, Guid? userId)
        {
            return queryable.Where(u => (u.UserId == userId || (userId == null && u.UserId == null)));
        }
    }
}
