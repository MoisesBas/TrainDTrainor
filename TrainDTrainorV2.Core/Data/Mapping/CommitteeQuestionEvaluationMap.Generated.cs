using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class CommitteeQuestionEvaluationMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.CommitteeQuestionEvaluation>
    {
        public void Configure(EntityTypeBuilder<CommitteeQuestionEvaluation> builder)
        {
            builder.ToTable("tblCommitteeQuestionEvaluations", "dbo");
            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.CommitteeId)
               .IsRequired()
               .HasColumnName("CommitteeId");           
            builder.Property(t => t.TraineeId)
              .IsRequired()
              .HasColumnName("TraineeId");
            builder.Property(t => t.BuildCourseAttendeeId)
             .IsRequired()
             .HasColumnName("BuildCourseAttendeeId");
            builder.Property(t => t.CommitteeQuestionId)
            .IsRequired()
            .HasColumnName("CommitteeQuestionId");
            builder.Property(t => t.Evaluation)
              .IsRequired()
              .HasColumnName("Evaluation");
            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.Created)
                .IsRequired()
                .HasColumnName("Created")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasMaxLength(100);
            builder.Property(t => t.Updated)
                .IsRequired()
                .HasColumnName("Updated")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasMaxLength(100);
            builder.Property(t => t.RowVersion)
                .IsRequired()
                .IsRowVersion()
                .HasColumnName("RowVersion")
                .HasMaxLength(8)
                .ValueGeneratedOnAddOrUpdate();

            //relationship

            //builder.HasOne(t => t.Committee)
            //   .WithMany(t => t.CommitteeQuestionEvaluations)
            //   .HasForeignKey(t => t.CommitteeId)
            //   .HasConstraintName("FK_CommitteeQuestionEvaluations_Committee_CommitteeId");
            //builder.HasOne(t => t.Trainee)
            //   .WithMany(t => t.TraineeQuestionEvaluations)
            //   .HasForeignKey(t => t.TraineeId)
            //   .HasConstraintName("FK_TraineeQuestionEvaluations_Trainee_TraineeId");

            builder.HasOne(t => t.TrainingCourseAttendee)
               .WithMany(t => t.CommitteeQuestionEvaluations)
               .HasForeignKey(t => t.BuildCourseAttendeeId)
               .HasConstraintName("FK_CommitteeQuestionEvaluations_TrainingCourseAttendee_BuildCourseAttendeeId");

            builder.HasOne(t => t.CommitteeQuestion)
              .WithMany(t => t.TraineeQuestionEvaluations)
              .HasForeignKey(t => t.CommitteeQuestionId)
              .HasConstraintName("FK_TraineeQuestionEvaluations_CommitteeQuestion_CommitteeQuestionId");
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.CommitteeQuestionEvaluation> builder);
    }
}
