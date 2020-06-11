using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Models;

namespace TrainDTrainorV2.Core.Domain.Payment.Models
{
   public class PaymentCreateModel:EntityCreateModel<Guid>
    {       
        public Guid? CourseId { get; set; }
        public Guid? UserProfileId { get; set; }
        public string PaymentPicId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Status { get; set; }       
        public IFormFile File { get; set; }
    }
}
