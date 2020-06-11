using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class TrainingBuildCourseMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourse>
    {
        public void Configure(EntityTypeBuilder<TrainingBuildCourse> builder)
        {
            builder.ToTable("tblTrainingBuildCourses", "dbo");
            builder.HasKey(t => t.Id);           
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.CourseId)
                .IsRequired()
                .HasColumnName("CourseId");
            builder.Property(t => t.LevelId)
                .IsRequired()
                .HasColumnName("LevelId");
            builder.Property(t => t.QuestionId)
                .IsRequired()
                .HasColumnName("QuestionId");
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
            builder.HasOne(t => t.Question)
              .WithMany(t => t.TrainingBuildCourses)
              .HasForeignKey(d => d.QuestionId)
              .HasConstraintName("FK_TrainingBuildCourses_Question_QuestionId");
            builder.HasOne(t => t.Level)
             .WithMany(t => t.TrainingBuildCourses)
             .HasForeignKey(d => d.LevelId)
             .HasConstraintName("FK_TrainingBuildCourses_Level_LevelId");

            builder.HasOne(t => t.Course)
             .WithMany(t => t.TrainingBuildCourses)
             .HasForeignKey(d => d.CourseId)
             .HasConstraintName("FK_TrainingBuildCourses_Course_CourseId");

            InitializeMapping(builder);

        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TrainingBuildCourse> builder);
    }
}


