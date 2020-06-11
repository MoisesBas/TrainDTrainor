using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void MappingConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Data.Mapping.UserMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.RoleMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.UserProfileMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.UserRoleMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.RefreshTokenMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.UserLoginMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.EmailDeliveryMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.EmailTemplateMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.EducationMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.UserProfileAchievementMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.PaymentTransactionMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.PaymentTransactionHistoryMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.UserProfileJobHistoryMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TrainingMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TrainingCourseMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TrainingBuildCourseMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TrainingBuildCourseAttendeeMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TrainingVideoMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TraineeEvaluationMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TraineeEvaluationVideoMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.LevelMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.LevelQuestionMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.CourseMaterialMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.LevelVideoMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.SMSDeliveryMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.SMSTemplateMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TrainingExperienceMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.LevelSubjectMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.UserProfilePicMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.PaymentTransactionPicMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.LevelVideoPicMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TrainingVideoPicMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.CountryMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TrainingExamMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.TraineeExamResultMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.CommitteeQuestionMap());
            modelBuilder.ApplyConfiguration(new Data.Mapping.CommitteeQuestionEvaluationMap());
        }
    }
}
