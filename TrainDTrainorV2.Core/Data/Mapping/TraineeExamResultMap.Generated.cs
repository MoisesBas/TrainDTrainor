using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{

    public partial class TraineeExamResultMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TraineeExamResult>
    {
        public void Configure(EntityTypeBuilder<TraineeExamResult> builder)
        {
            builder.ToTable("tblTraineeExamResults", "dbo");
            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.UserId)
               .IsRequired()
               .HasColumnName("UserId");

            builder.Property(t => t.QuestionId)
                .IsRequired()
                .HasColumnName("QuestionId");
            builder.Property(t => t.CourseId)
               .IsRequired()
               .HasColumnName("CourseId");
            builder.Property(t => t.IsCorrect)
              .HasColumnName("IsCorrect")
              .HasDefaultValueSql("((0))");
            builder.Property(t => t.Answer)
                .HasColumnName("Answer")
                .HasMaxLength(100);
            builder.Property(t => t.IsActive)
                .IsRequired()
                .HasColumnName("IsActive")
                .HasDefaultValueSql("((1))");
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
            builder.HasOne(t => t.Course)
                 .WithMany(t => t.ExamResults)
                 .HasForeignKey(d => d.CourseId)
              .HasConstraintName("FK_ExamResults_Course_CourseId");
            builder.HasOne(t => t.Question)
                .WithMany(t => t.ExamResults)
                .HasForeignKey(d => d.QuestionId)
             .HasConstraintName("FK_ExamResults_Question_QuestionId");
            builder.HasOne(t => t.User)
               .WithMany(t => t.ExamResults)
               .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_ExamResults_User_UserId");
            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TraineeExamResult> builder);
    }
}
