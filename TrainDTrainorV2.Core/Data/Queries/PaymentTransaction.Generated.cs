using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainDTrainorV2.Core.Data.Queries
{
   public static partial class PaymentTransaction
    {
        public static Task<TrainDTrainorV2.Core.Data.Entities.PaymentTransaction> GetByUserProfileId(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.PaymentTransaction> queryable, Guid id)
        {
            return queryable.FirstOrDefaultAsync(i => i.UserProfileId == id);
        }
        public static TrainDTrainorV2.Core.Data.Entities.PaymentTransaction GetById(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.PaymentTransaction> queryable, Guid id)
        {
            return queryable.FirstOrDefault(i => i.Id == id);
        }

    }
}
