using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
  public static partial  class TrainingExtensions
    {
        public static TrainDTrainorV2.Core.Data.Entities.Training GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.Training> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.Training>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(i => i.Id == id);
        }
        public static Task<TrainDTrainorV2.Core.Data.Entities.Training> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.Training> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.Training>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(i => i.Id == id);
        }       
    }
}
