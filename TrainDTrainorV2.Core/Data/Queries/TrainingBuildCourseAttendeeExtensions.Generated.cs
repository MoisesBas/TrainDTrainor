using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
  public static partial class TrainingBuildCourseAttendeeExtensions
    {
        public static TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(i => i.Id == id);
        }
        public static Task<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(i => i.Id == id);
        }
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee> GetCourseByAttendeeId(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee>;
            if (dbSet != null)
                return dbSet.Where(x => x.AttendeeId == id);
            return queryable.Where(i => i.AttendeeId == id);

        }
    }
}
