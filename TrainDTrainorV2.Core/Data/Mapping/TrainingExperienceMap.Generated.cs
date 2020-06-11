﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class TrainingExperienceMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TrainingExperience>
    {
        public void Configure(EntityTypeBuilder<TrainingExperience> builder)
        {
            // table
            builder.ToTable("tblUserProfileTrainingExperience", "dbo");

            // keys
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CourseName)
               .HasColumnName("CourseName")
               .HasMaxLength(150);
            builder.Property(t => t.Location)
              .HasColumnName("Location")
              .HasMaxLength(150);
            builder.Property(t => t.Attended)
             .HasColumnName("Attended");
            builder.Property(t => t.Year)
              .HasColumnName("Year");
            builder.Property(t => t.UserProfileId)
             .HasColumnName("UserProfileId");
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

            builder.HasOne(t => t.UserProfile)
               .WithMany(t => t.TrainingExperiences)
               .HasForeignKey(t => t.UserProfileId)
               .HasConstraintName("FK_TrainingExperiences_UserProfile_UserProfileId");
            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TrainingExperience> builder);
    }
    
}