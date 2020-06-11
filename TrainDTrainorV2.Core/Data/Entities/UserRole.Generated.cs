using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class UserRole
    {
        public UserRole()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;          
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }        
        public Guid RoleId { get; set; }
        public bool? IsDeleted { get; set; }
        public int UserType { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
