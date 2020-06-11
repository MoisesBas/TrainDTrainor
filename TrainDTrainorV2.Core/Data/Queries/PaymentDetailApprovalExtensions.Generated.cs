using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrainDTrainorV2.CommandQuery.Queries;

namespace TrainDTrainorV2.Core.Data.Queries
{
    public static partial class PaymentDetailApprovalExtensions
    {
        public static IQueryable<TrainDTrainorV2.Core.Data.Entities.PaymentDetailApproval> GetPaymentTransactions(this System.Linq.IQueryable<TrainDTrainorV2.Core.Data.Entities.PaymentTransaction> queryable)
        {
            var dbSet = queryable as DbSet<TrainDTrainorV2.Core.Data.Entities.PaymentTransaction>;
            return dbSet
               .Include(x => x.UserProfile)
               .ThenInclude(x => x.User)
               .Include(x => x.Course)
               .Select(p => new TrainDTrainorV2.Core.Data.Entities.PaymentDetailApproval
               {
                   Id = p.Id,
                   CourseId = p.CourseId,
                   Course = p.Course.Title,
                   UserProfileId = p.UserProfileId,
                   Status = p.Status,
                   FullName = p.UserProfile.FullName,
                   Country = p.UserProfile.Country,
                   City = p.UserProfile.City,
                   Age = p.UserProfile.Age,
                   Nationality = p.UserProfile.Nationality,
                   JobTitle = p.UserProfile.JobTitle,
                   EmailAddress = p.UserProfile.EmailAddress,
                   MobilePhone = p.UserProfile.MobilePhone,
                   BusinessPhone = p.UserProfile.BusinessPhone,
                   UserId = p.UserProfile.UserId,
                   Created = p.Created,
                   CreatedBy = p.CreatedBy,
                   Updated = p.Updated,
                   UpdatedBy = p.UpdatedBy
               });
        }
        
    }
}
