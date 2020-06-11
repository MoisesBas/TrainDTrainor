using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class EducationMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("tblUserProfileEducations", "dbo");

            // keys
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.UserProfileId)
             .HasColumnName("UserProfileId");

            builder.Property(t => t.DegreeName)
               .IsRequired()
               .HasColumnName("DegreeName")
               .HasMaxLength(256);
            builder.Property(t => t.NameOfInstitute)
              .HasColumnName("NameOfInstitute")
              .HasMaxLength(256);
            builder.Property(t => t.EducationLevel)
                .HasColumnName("EducationLevel")
                .HasMaxLength(256);
            builder.Property(t => t.Year)
               .HasColumnName("Year");               
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
            builder.HasOne(t => t.UserProfile)
              .WithMany(t => t.Educations)
              .HasForeignKey(d => d.UserProfileId)
              .HasConstraintName("FK_Educations_UserProfile_UserProfileId");

            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.Education> builder);
    }
}
