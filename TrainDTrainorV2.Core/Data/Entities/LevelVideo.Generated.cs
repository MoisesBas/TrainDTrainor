using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class LevelVideo
    {
        public LevelVideo()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;

        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? LevelId { get; set; }
        public Guid? FileId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsMobile { get; set; }
        public bool IsDesktop { get; set; }       
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual Level Level { get; set; }       
        
    }
}
