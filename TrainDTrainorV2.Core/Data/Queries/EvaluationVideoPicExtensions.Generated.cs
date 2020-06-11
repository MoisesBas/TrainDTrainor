using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Queries
{
  public static partial class EvaluationVideoPicExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.EvaluationVideoPic> GetPathByName(this IQueryable<TrainDTrainorV2.Core.Data.Entities.EvaluationVideoPic> queryable, string name)
        {
            return queryable.Where(u => u.Name == name);
        }

        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.EvaluationVideoPic> GetEvaluationVideoId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.EvaluationVideoPic> queryable, Guid? Id)
        {
            return Id.HasValue ? queryable.Where(u => u.Stream_id == Id) : null;
        }
    }
}
