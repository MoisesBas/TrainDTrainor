using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class Education
    {
        public Education()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }
        public Guid Id { get; set; }
        public Guid? UserProfileId { get; set; }
        public string DegreeName { get; set; }
        public string NameOfInstitute { get; set; }
        public string EducationLevel { get; set; }
        public int Year { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
