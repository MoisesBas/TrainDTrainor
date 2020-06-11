using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class TraineeEvaluationVideo
    {
        public TraineeEvaluationVideo()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
        }
        public Guid Id { get; set; }  
        public string Name { get; set; }
        public string Description { get; set; }        
        public Guid? FileId { get; set; }
        public Guid? TrainingBuildCourseAttendeeId { get; set; }
        public Guid? CourseLevelId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }        
        public virtual Level CourseLevel { get; set; }    
        public virtual TrainingBuildCourseAttendee TrainingBuildCourseAttendee { get; set; }
        

    }
}
