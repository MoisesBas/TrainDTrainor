using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class SMSDelivery
    {
        public SMSDelivery()
        {
            Attempts = 0;
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }

        public Guid Id { get; set; }
        public bool IsProcessing { get; set; }
        public bool IsDelivered { get; set; }
        public DateTimeOffset? Delivered { get; set; }
        public int Attempts { get; set; }
        public DateTimeOffset? LastAttempt { get; set; }
        public DateTimeOffset? NextAttempt { get; set; }
        public Guid UserId { get; set; }
        public string SMSLog { get; set; }
        public string Error { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Message { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        
        public Byte[] RowVersion { get; set; }
        public virtual User User { get; set; }
    }
}
