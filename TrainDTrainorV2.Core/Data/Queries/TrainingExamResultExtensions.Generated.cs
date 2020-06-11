using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class TrainingExamResultExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.TraineeExamResult> GetExamByTraineeIdAndCourseId(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.TraineeExamResult> queryable, Guid courseId, Guid userId)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.TraineeExamResult>;
            if (dbSet != null)
                return dbSet.Where(x => x.CourseId == courseId && x.UserId == userId);
            return queryable.Where(x => x.CourseId.Equals(courseId) && x.UserId.Equals(userId));

        }
    }
}
