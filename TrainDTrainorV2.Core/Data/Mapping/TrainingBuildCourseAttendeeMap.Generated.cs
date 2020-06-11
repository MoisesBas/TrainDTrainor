using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class TrainingBuildCourseAttendeeMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee>
    {
        public void Configure(EntityTypeBuilder<TrainingBuildCourseAttendee> builder)
        {
            builder.ToTable("tblTrainingBuildCourseAttendees", "dbo");
            // keys
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.AttendeeId)
               .IsRequired()
               .HasColumnName("AttendeeId");

            builder.Property(t => t.CourseId)
              .IsRequired()
              .HasColumnName("CourseId");

            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasDefaultValueSql("((0))");

            builder.Property(t => t.IsActive)
               .IsRequired()
               .HasColumnName("IsActive")
               .HasDefaultValueSql("((1))");

            builder.Property(t => t.TrainingBuildCourseParentId)                
                .HasColumnName("TrainingBuildCourseParentId");
            
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
            builder.HasOne(t => t.TrainingCourseAttendee)
             .WithMany(t => t.TrainingBuildCourseAttendees)
             .HasForeignKey(d => d.TrainingBuildCourseParentId)
             .HasConstraintName("FK_TrainingBuildCourseAttendees_TrainingCourseAttendee_TrainingBuildCourseParentId");

            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourseAttendee> builder);
    }
}
