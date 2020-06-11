using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class TraineeEvaluationVideoMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TraineeEvaluationVideo>
    {
        public void Configure(EntityTypeBuilder<TraineeEvaluationVideo> builder)
        {
            builder.ToTable("tblTraineeEvaluationVideos", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasMaxLength(256);
            builder.Property(t => t.Description)
              .IsRequired()
              .HasColumnName("Description")
              .HasMaxLength(256);
            builder.Property(t => t.TrainingBuildCourseAttendeeId)
              .IsRequired()
              .HasColumnName("TrainingBuildCourseAttendeeId");
            builder.Property(t => t.FileId)
             .IsRequired()
             .HasColumnName("FileId");
            builder.Property(t => t.CourseLevelId)
             .IsRequired()
             .HasColumnName("CourseLevelId");
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

            // Relationships            
            builder.HasOne(t => t.TrainingBuildCourseAttendee)
                .WithMany(t => t.TraineeEvaluationVideos)
                .HasForeignKey(t => t.TrainingBuildCourseAttendeeId)
                .HasConstraintName("FK_TraineeEvaluationVideos_TrainingBuildCourseAttendee_TrainingBuildCourseAttendeeId");

            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TraineeEvaluationVideo> builder);
    }
}
