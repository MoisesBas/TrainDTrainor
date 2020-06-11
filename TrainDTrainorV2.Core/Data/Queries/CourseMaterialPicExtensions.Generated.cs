using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Queries
{
  public static partial class CourseMaterialPicExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.CourseMaterialPic> GetPathByName(this IQueryable<TrainDTrainorV2.Core.Data.Entities.CourseMaterialPic> queryable, string name)
        {
            return queryable.Where(u => u.Name == name);
        }

        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.CourseMaterialPic> GetCourseMaterialId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.CourseMaterialPic> queryable, Guid? Id)
        {
            return Id.HasValue ? queryable.Where(u => u.Stream_id == Id) : null;
        }
    }
}
