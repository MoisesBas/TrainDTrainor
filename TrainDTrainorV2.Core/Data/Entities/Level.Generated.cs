using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class Level
    {
        public Level()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            LevelQuestions = new HashSet<LevelQuestion>();
            LevelVideos = new HashSet<LevelVideo>();
            TrainingBuildCourses = new HashSet<TrainingBuildCourse>();
            Subjects = new HashSet<LevelSubject>();
        }
        public Guid Id { get; set; }
        public Guid TrainingId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual ICollection<LevelQuestion> LevelQuestions { get; set; }
        public virtual ICollection<LevelVideo> LevelVideos { get; set; }
        public virtual ICollection<TrainingBuildCourse> TrainingBuildCourses { get; set; }       
        public virtual ICollection<LevelSubject> Subjects { get; set; } 
        public virtual Training Training { get; set; }


    }
}
