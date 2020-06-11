using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class RoleExtensions
    {

        
        public static TrainDTrainorV2.Core.Data.Entities.Role GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.Role> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.Role>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(r => r.Id == id);
        }

       
        public static Task<TrainDTrainorV2.Core.Data.Entities.Role> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.Role> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.Role>;
            if (dbSet != null)
                return dbSet.FindAsync(id);
            return queryable.FirstOrDefaultAsync(r => r.Id == id);
        }

        public static TrainDTrainorV2.Core.Data.Entities.Role GetByName(this IQueryable<TrainDTrainorV2.Core.Data.Entities.Role> queryable, string name)
        {
            return queryable.FirstOrDefault(r => r.Name == name);
        }

        public static Task<TrainDTrainorV2.Core.Data.Entities.Role> GetByNameAsync(this IQueryable<TrainDTrainorV2.Core.Data.Entities.Role> queryable, string name)
        {
            return queryable.FirstOrDefaultAsync(r => r.Name == name);
        }
    }
}
