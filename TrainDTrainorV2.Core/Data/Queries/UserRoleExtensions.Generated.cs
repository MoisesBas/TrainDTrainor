using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class UserRoleExtensions
    {

       
        public static TrainDTrainorV2.Core.Data.Entities.UserRole GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.UserRole> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.UserRole>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(u => u.Id == id);
        }
        
        public static Task<TrainDTrainorV2.Core.Data.Entities.UserRole> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.UserRole> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.UserRole>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(u => u.Id == id);
        }

        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.UserRole> ByUserId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.UserRole> queryable, Guid userId)
        {
            return queryable.Where(u => u.UserId == userId);
        }      
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.UserRole> ByRoleId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.UserRole> queryable, Guid roleId)
        {
            return queryable.Where(u => u.RoleId == roleId);
        }
    }
}
