using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
   public partial class PaymentTransactionHistory
    {
        public PaymentTransactionHistory()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }
        public Guid Id { get; set; }      
       
        public Guid? CourseId { get; set; }
        public Guid? PaymentTransactionId { get; set; }
        public Guid? UserProfileId { get; set; }
        public DateTime PaymentDate { get; set; }
        public Decimal Amount { get; set; }
        public Guid? FileId { get; set; }
        public int Status { get; set; }
        public bool? IsDeleted { get; set; }
        public string Comments { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual TrainingCourse Course { get; set; }        
        public virtual PaymentTransaction PaymentTransaction { get; set; }
    }
}
