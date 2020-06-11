using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Queries
{
  public static partial  class TrainingExperienceExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfile> GetTrainingExperienceByUserId(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.UserProfile> queryable)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.UserProfile>;
            return dbSet.Include(x => x.TrainingExperiences);            
        }
    }
}
