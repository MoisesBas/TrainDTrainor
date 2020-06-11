using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Queries
{
  public static partial class UserProfilePicExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfilePic> GetPathByName(this IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfilePic> queryable, string name)
        {
            return queryable.Where(u => u.Name == name);
        }

        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfilePic> GetProfilePicId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfilePic> queryable, Guid? profileId)
        {
            return profileId.HasValue ? queryable.Where(u => u.Stream_id == profileId) : null;
        }
    }
}
