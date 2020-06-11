using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
  public partial  class PaymentDetailApproval
    {
        public PaymentDetailApproval()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }
        public Guid Id { get; set; }
        public Guid? CourseId { get; set; }
        public string Course { get; set; }
        public Guid? UserProfileId { get; set; }        
        public int Status { get; set; }        
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string JobTitle { get; set; }
        public string MobilePhone { get; set; }
        public string BusinessPhone { get; set; }
        public Guid PaymentPicId { get; set; }
        public Decimal Amount { get; set; }
        public Guid? UserId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public string RowVersion { get; set; }
    }
}
