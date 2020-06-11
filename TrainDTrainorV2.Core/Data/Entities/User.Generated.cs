using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class User
    {
        public User()
        {
            AccessFailedCount = 0;
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            RefreshTokens = new HashSet<RefreshToken>();
            UserLogins = new HashSet<UserLogin>();
            UserRoles = new HashSet<UserRole>();
            UserTrainings = new HashSet<TrainingBuildCourseAttendee>();
            UserCourses = new HashSet<TrainingCourse>();
            ExamResults = new HashSet<TraineeExamResult>();        
            //CommitteeQuestionEvaluations = new HashSet<CommitteeQuestionEvaluation>();
            //TraineeQuestionEvaluations = new HashSet<CommitteeQuestionEvaluation>();
        }
        public Guid Id { get; set; }
        public string EmailAddress { get; set; }
        public bool IsEmailAddressConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public string DisplayName { get; set; }
        public string PasswordHash { get; set; }
        public string ResetHash { get; set; }
        public string InviteHash { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public DateTimeOffset? LastLogin { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsGlobalAdministrator { get; set; }
        public bool IsAgree { get; set; }
        public string OTP { get; set; }        
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public Byte[] RowVersion { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<UserLogin> UserLogins { get; set; }
        //public virtual ICollection<CommitteeQuestionEvaluation> CommitteeQuestionEvaluations { get; set; }
        //public virtual ICollection<CommitteeQuestionEvaluation> TraineeQuestionEvaluations { get; set; }
        public virtual UserProfile UserProfiles { get; set; }  
        public virtual ICollection<UserRole> UserRoles { get; set; }       
        public virtual ICollection<TrainingCourse> UserCourses { get; set; }
        public virtual ICollection<TrainingBuildCourseAttendee> UserTrainings { get; set; }
        public virtual ICollection<TraineeExamResult> ExamResults { get; set; }
        public virtual ICollection<SMSDelivery> SMSDeliveries { get; set; }

    }
}
