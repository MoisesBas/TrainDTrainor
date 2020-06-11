using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class TraineeEvaluationMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TraineeEvaluation>
    {
        public void Configure(EntityTypeBuilder<TraineeEvaluation> builder)
        {
            builder.ToTable("tblTraineeEvaluations", "dbo");
            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.TrainingCourseAttendeeId)
               .IsRequired()
               .HasColumnName("TrainingCourseAttendeeId");           
            builder.Property(t => t.EvaluatorId)
              .IsRequired()
              .HasColumnName("EvaluatorId");
            
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
           
            
           
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TraineeEvaluation> builder);
    }
}
