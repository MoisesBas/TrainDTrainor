using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class TrainingBuildCourseAttendee
    {
        public TrainingBuildCourseAttendee()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            TraineeEvaluations = new HashSet<TraineeEvaluation>();
            TraineeEvaluationVideos = new HashSet<TraineeEvaluationVideo>();
            TrainingBuildCourseAttendees = new HashSet<TrainingBuildCourseAttendee>();
            CommitteeQuestionEvaluations = new HashSet<CommitteeQuestionEvaluation>();
        }
        public Guid Id { get; set; }
        public Guid AttendeeId { get; set; }
        public Guid CourseId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public Guid? TrainingBuildCourseParentId { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual User Attendee { get; set; }
        public virtual TrainingCourse Course { get; set; }
        public virtual TrainingBuildCourseAttendee TrainingCourseAttendee { get; set; }
        public virtual ICollection<TrainingBuildCourseAttendee> TrainingBuildCourseAttendees { get; set; }
        public virtual ICollection<TraineeEvaluation> TraineeEvaluations { get; set; }
        public virtual ICollection<TraineeEvaluationVideo> TraineeEvaluationVideos { get; set; }
        public virtual ICollection<CommitteeQuestionEvaluation> CommitteeQuestionEvaluations { get; set; }
    }
}
