using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Queries
{
  public static partial class PaymentTransactionPicExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.PaymentTransactionPic> GetPathByName(this IQueryable<TrainDTrainorV2.Core.Data.Entities.PaymentTransactionPic> queryable, string name)
        {
            return queryable.Where(u => u.Name == name);
        }

        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.PaymentTransactionPic> GetProfilePicId(this IQueryable<TrainDTrainorV2.Core.Data.Entities.PaymentTransactionPic> queryable, Guid? paymentpicId)
        {
            return paymentpicId.HasValue ? queryable.Where(u => u.Stream_id == paymentpicId) : null;
        }
    }
}
