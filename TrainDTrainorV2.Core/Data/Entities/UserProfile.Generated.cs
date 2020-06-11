using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Entities
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Created = DateTimeOffset.UtcNow;
            Updated = DateTimeOffset.UtcNow;
            Educations = new HashSet<Education>();
            JobHistories = new HashSet<UserProfileJobHistory>();
            Achievements = new HashSet<UserProfileAchievements>();
            PaymentTransactions = new HashSet<PaymentTransaction>();
            TrainingExperiences = new HashSet<TrainingExperience>();
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        public string City { get; set; }        
        public string JobTitle { get; set; }    
        public string BusinessPhone { get; set; }
        public Guid? FileId { get; set; }
        public string MongoDbProfileCVId { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTimeOffset Updated { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsPaid { get; set; }
        public Byte[] RowVersion { get; set; }      
        public virtual User User { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<UserProfileJobHistory> JobHistories { get; set; }
        public virtual ICollection<UserProfileAchievements> Achievements { get; set; }
        public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } 
        public virtual ICollection<TrainingExperience> TrainingExperiences { get; set; }
    }
}
