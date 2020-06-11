using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class CourseExtensions
    {
        public static TrainDTrainorV2.Core.Data.Entities.TrainingCourse GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingCourse>;
            if (dbSet != null)
                return dbSet.Find(id);

            return queryable.FirstOrDefault(i => i.Id == id);
        }
        public static Task<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingCourse>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(i => i.Id == id);
        }
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> GetCourseByTrainorId(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> queryable, Guid trainorId)
        {
            return queryable.Where(x=>x.TrainorId == trainorId);
        }

        public static Task<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> GetAllCourseNotInAttendee(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> queryable, int[] courseId)
        {
            //var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingCourse>;
            //if (dbSet != null)
            //    return dbSet.Where(x=>courseId.ToArray().Contains(x.Id));

            //return queryable.FirstOrDefaultAsync(i => i.Id == id);
            return null;
        }
    }
}
