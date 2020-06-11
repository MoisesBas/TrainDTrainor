using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class TrainingVideoExtensions
    {
        public static TrainDTrainorV2.Core.Data.Entities.TrainingVideo GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingVideo> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingVideo>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(i => i.Id == id);
        }
        public static Task<TrainDTrainorV2.Core.Data.Entities.TrainingVideo> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingVideo> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingVideo>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
