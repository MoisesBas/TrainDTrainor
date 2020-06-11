using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;
namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class UserProfileJobHistoryMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.UserProfileJobHistory>
    {
        public void Configure(EntityTypeBuilder<UserProfileJobHistory> builder)
        {
            builder.ToTable("tblUserProfileJobHistories", "dbo");
            // keys
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.UserProfileId)
                .IsRequired()
                .HasColumnName("UserProfileId");            
            builder.Property(t => t.Position)
               .HasColumnName("Position")
               .HasMaxLength(150);
            builder.Property(t => t.CompanyName)
              .HasColumnName("CompanyName")
              .HasMaxLength(150);
            builder.Property(t => t.Years)
             .HasColumnName("Years");
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
           .WithMany(t => t.JobHistories)
           .HasForeignKey(d => d.UserProfileId)
           .HasConstraintName("FK_JobHistories_UserProfile_UserProfileId");
            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.UserProfileJobHistory> builder);
    }
}
