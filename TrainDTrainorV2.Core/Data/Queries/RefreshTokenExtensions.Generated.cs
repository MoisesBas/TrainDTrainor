using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class RefreshTokenExtensions
    {

        
        public static TrainDTrainorV2.Core.Data.Entities.RefreshToken GetByKey(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.RefreshToken> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.RefreshToken>;
            if (dbSet != null)
                return dbSet.Find(id);
            return queryable.FirstOrDefault(r => r.Id == id);
        }

        
        public static Task<TrainDTrainorV2.Core.Data.Entities.RefreshToken> GetByKeyAsync(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.RefreshToken> queryable, Guid id)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.RefreshToken>;
            if (dbSet != null)
                return dbSet.FindAsync(id);

            return queryable.FirstOrDefaultAsync(r => r.Id == id);
        }       
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.RefreshToken> ByUserId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.RefreshToken> queryable, Guid userId)
        {
            return queryable.Where(r => r.UserId == userId);
        }       
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.RefreshToken> ByUserName(this IQueryable<TrainDTrainorV2.Core.Data.Entities.RefreshToken> queryable, string userName)
        {
            return queryable.Where(r => r.UserName == userName);
        }
        
        public static TrainDTrainorV2.Core.Data.Entities.RefreshToken GetByTokenHashed(this IQueryable<TrainDTrainorV2.Core.Data.Entities.RefreshToken> queryable, string tokenHashed)
        {
            return queryable.FirstOrDefault(r => r.TokenHashed == tokenHashed);
        }

        public static Task<TrainDTrainorV2.Core.Data.Entities.RefreshToken> GetByTokenHashedAsync(this IQueryable<TrainDTrainorV2.Core.Data.Entities.RefreshToken> queryable, string tokenHashed)
        {
            return queryable.FirstOrDefaultAsync(r => r.TokenHashed == tokenHashed);
        }
    }
}
