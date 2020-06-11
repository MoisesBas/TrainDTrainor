using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    
    public partial class TrainingExamMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TrainingExam>
    {
        public void Configure(EntityTypeBuilder<TrainingExam> builder)
        {
            builder.ToTable("tblTrainingExams", "dbo");
            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.TrainingId)
               .IsRequired()
               .HasColumnName("TrainingId");               
            builder.Property(t => t.Question)
                .IsRequired()
                .HasColumnName("Question")
                .HasMaxLength(256);

            builder.Property(t => t.Content)
               .HasColumnName("Content")
               .HasMaxLength(256);
            builder.Property(t => t.QuestionType)
                .HasColumnName("QuestionType");
            builder.Property(t => t.Answer)
               .HasColumnName("Answer")
               .HasMaxLength(256);
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
           builder.HasOne(t=>t.Training)
                .WithMany(t=>t.TrainingExams)
                .HasForeignKey(d => d.TrainingId)
             .HasConstraintName("FK_TrainingExams_Training_TrainingId");
            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TrainingExam> builder);
    }
}
