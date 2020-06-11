using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.PaymentHistory.Models
{
   public class PaymentHistoryCreateModel: EntityCreateModel<Guid>
    {       
        public Guid? CourseId { get; set; }
        public Guid? UserProfileId { get; set; }
        public string PaymentPicId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Status { get; set; }  
        public Guid? PaymentTransactionId { get; set; }
        public Guid? FileId { get; set; }
        public string Comments { get; set; }
    }
}
