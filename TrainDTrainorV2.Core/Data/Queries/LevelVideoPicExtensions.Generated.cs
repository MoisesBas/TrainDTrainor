using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Queries
{
  public static partial class LevelVideoPicExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.LevelVideoPic> GetPathByName(this IQueryable<TrainDTrainorV2.Core.Data.Entities.LevelVideoPic> queryable, string name)
        {
            return queryable.Where(u => u.Name == name);
        }

        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.LevelVideoPic> GetLevelVidoePicId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.LevelVideoPic> queryable, Guid? levelVideoId)
        {
            return levelVideoId.HasValue ? queryable.Where(u => u.Stream_id == levelVideoId) : null;
        }
    }
}
