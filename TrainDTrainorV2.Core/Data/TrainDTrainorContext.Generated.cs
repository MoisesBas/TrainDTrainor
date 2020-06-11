using AutoMapper;
using CodeFirstStoredProcs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrainDTrainorV2.CommandQuery.Definitions;
using TrainDTrainorV2.Core.Data.Entities;
using TrainDTrainorV2.Core.Data.Queries;
using TrainDTrainorV2.Core.Extensions;

namespace TrainDTrainorV2.Core.Data
{
    public partial class TrainDTrainorContext
        : DbContext
    {
        private readonly object[] skipdelete = new object[] {
                                           typeof(UserProfilePic).FullName,
                                           typeof(PaymentTransactionPic).FullName,
                                           typeof(LevelVideoPic).FullName,
                                           typeof(TrainingVideoPic).FullName,
                                           typeof(EvaluationVideoPic).FullName,
                                           typeof(CourseMaterialPic).FullName
        };
        public TrainDTrainorContext()
        {
        }
        public TrainDTrainorContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.Role> Roles { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.UserRole> UserRoles { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.User> Users { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.UserProfile> UserProfiles { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.Education> Educations { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.UserProfileJobHistory> UserProfileJobHistories { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.UserProfileAchievements> UserProfileAchievements { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.PaymentTransactionHistory> PaymentTransactionHistories { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.UserLogin> UserLogins { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.RefreshToken> RefreshTokens { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> EmailTemplates { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.SMSTemplate> SMSTemplates { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.SMSDelivery> SMSDeliveries { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.EmailDelivery> EmailDeliveries { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.Training> Training { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> TrainingCourse { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourse> TrainingBuildCourses { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee> TrainingBuildCourseAttendees { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.CourseMaterial> CourseMaterials { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingVideo> TrainingVideo { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.Level> Levels { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.LevelQuestion> LevelQuestions { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.Country> Countries { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.LevelVideo> LevelVideos { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TraineeEvaluationVideo> TraineeEvaluationVideos { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TraineeEvaluation> TraineeEvaluations { get; set; }
        //public DbQuery<TrainDTrainorV2.Core.Data.Entities.PaymentDetailApproval> PaymentDetailApprovals { get; set; }      
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingExperience> UserTrainingExperience { get; set; }   
        public DbSet<TrainDTrainorV2.Core.Data.Entities.LevelSubject> LevelSubjects { get; set; }

        public DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingExam> TrainingExams { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.CommitteeQuestion>
            CommitteeQuestions
        { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.CommitteeQuestionEvaluation>
           CommitteeQuestionEvaluations
        { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TraineeExamResult> ExamResults { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.EvaluationVideoPic> EvaluationVideoPicFiletable { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.UserProfilePic> ProfilePicFiletable { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.PaymentTransactionPic> PaymentPicFiletable { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.LevelVideoPic> LevelVideoPicFiletable { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.TrainingVideoPic> TrainingVideoPicFiletable { get; set; }
        public DbSet<TrainDTrainorV2.Core.Data.Entities.CourseMaterialPic> CourseMaterialPicFiletable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MappingConfiguration();
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!skipdelete.Contains(entityType.Name))
                {
                    entityType.GetOrAddProperty("IsDeleted", typeof(bool));
                    var parameter = Expression.Parameter(entityType.ClrType);
                    var propertyMethodInfo = typeof(EF).GetMethod("Property").MakeGenericMethod(typeof(bool));
                    var isDeletedProperty = Expression.Call(propertyMethodInfo, parameter, Expression.Constant("IsDeleted"));
                    BinaryExpression compareExpression = Expression.MakeBinary(ExpressionType.Equal, isDeletedProperty, Expression.Constant(false));
                    var lambda = Expression.Lambda(compareExpression, parameter);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
                }
            }


            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                         .SelectMany(t => t.GetForeignKeys())
                                         .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            InitializeMapping(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            //WorkAround();
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            
            OnBeforeSaving();            
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }       

        private void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        foreach (var navigationEntry in entry.Navigations.Where(n => !n.Metadata.IsDependentToPrincipal()))
                        {
                            if (navigationEntry is CollectionEntry collectionEntry)
                            {
                                foreach (var dependentEntry in collectionEntry.CurrentValue)
                                {
                                    HandleDependent(Entry(dependentEntry));
                                }
                            }
                            else
                            {
                                var dependentEntry = navigationEntry.CurrentValue;
                                if (dependentEntry != null)
                                {
                                    HandleDependent(Entry(dependentEntry));
                                }
                            }
                        }                      
                        break;
                }
            }
        }
        private void HandleDependent(EntityEntry entry)
        {
            entry.CurrentValues["IsDeleted"] = true;
        }

        partial void InitializeMapping(ModelBuilder modelBuilder);

    }
}
