using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Queries
{
 public static partial   class TrainingVideoPicExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingVideoPic> GetPathByName(this IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingVideoPic> queryable, string name)
        {
            return queryable.Where(u => u.Name == name);
        }

        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingVideoPic> GetLevelVidoePicId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.TrainingVideoPic> queryable, Guid? fileId)
        {
            return fileId.HasValue ? queryable.Where(u => u.Stream_id == fileId) : null;
        }
    }
}
