using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.PaymentHistory.Models
{
   public class PaymentHistoryReadModel: EntityReadModel<Guid>
    {
        public Guid? CourseId { get; set; }
        public Guid? UserProfileId { get; set; }
        public Guid PaymentPicId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentPicPath { get; set; }
        public string FileName { get; set; }
        public int Status { get; set; }

    }
}
