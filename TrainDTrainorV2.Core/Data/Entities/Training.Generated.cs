using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{

   public partial class Training
    {
        public Training()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            TrainingCourses = new HashSet<TrainingCourse>();
            TrainingVideos = new HashSet<TrainingVideo>();            
            Levels = new HashSet<Level>();
            TrainingExams = new HashSet<TrainingExam>();
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual ICollection<TrainingCourse> TrainingCourses { get; set; }
        public virtual ICollection<TrainingVideo> TrainingVideos { get; set; }        
        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<TrainingExam> TrainingExams { get; set; }
    }
}
