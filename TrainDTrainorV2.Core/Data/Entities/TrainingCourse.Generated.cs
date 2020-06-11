using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.CommandQuery.Definitions;

namespace TrainDTrainorV2.Core.Data.Entities
{
   public partial class TrainingCourse
    {
        public TrainingCourse()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;           
            CourseMaterials = new HashSet<CourseMaterial>();
            TrainingBuildCourses = new HashSet<TrainingBuildCourse>();
            TrainingCourseAttendees = new HashSet<TrainingBuildCourseAttendee>();
            PaymentTransactions = new HashSet<PaymentTransaction>();
            ExamResults = new HashSet<TraineeExamResult>();
        }
        public Guid Id { get; set; }     
        public string Title { get; set; }
        public string Description { get; set; }
        public string Objectives { get; set; }
        public Guid? TrainorId { get; set; }
        public Guid? TrainingId { get; set; }
        public short CalendarYear { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string LocationMap { get; set; }
        public string Address { get; set; }
        public bool? IsDeleted { get; set; }
        public int MaxAttendee { get; set; }
        public int NoAttendee { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }   
        public virtual User Trainor { get; set; }   
        public virtual Training Training { get; set; }
        public virtual ICollection<CourseMaterial> CourseMaterials { get; set; }
        public virtual ICollection<TrainingBuildCourse> TrainingBuildCourses { get; set; }
        public virtual ICollection<TrainingBuildCourseAttendee> TrainingCourseAttendees { get; set; }
        public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; }
        public virtual ICollection<TraineeExamResult> ExamResults { get; set; }
    }
}
