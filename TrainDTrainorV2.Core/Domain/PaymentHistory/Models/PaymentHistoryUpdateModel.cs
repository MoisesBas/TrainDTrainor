using Microsoft.AspNetCore.Http;
using System;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.PaymentHistory.Models
{
    public class PaymentHistoryUpdateModel: EntityUpdateModel
    {
        
        public Guid? CourseId { get; set; }
        public Guid? UserProfileId { get; set; }
        public string PaymentPicId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Status { get; set; }
       
    }
}
