using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class UserLoginMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.UserLogin>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.UserLogin> builder)
        {
            // table
            builder.ToTable("tblUserLogins", "dbo");
            // keys
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.EmailAddress)
                .IsRequired()
                .HasColumnName("EmailAddress")
                .HasMaxLength(256);
            builder.Property(t => t.UserId)
                .HasColumnName("UserId");
            builder.Property(t => t.UserAgent)
                .HasColumnName("UserAgent");
            builder.Property(t => t.Browser)
                .HasColumnName("Browser")
                .HasMaxLength(256);
            builder.Property(t => t.OperatingSystem)
                .HasColumnName("OperatingSystem")
                .HasMaxLength(256);
            builder.Property(t => t.DeviceFamily)
                .HasColumnName("DeviceFamily")
                .HasMaxLength(256);
            builder.Property(t => t.DeviceBrand)
                .HasColumnName("DeviceBrand")
                .HasMaxLength(256);
            builder.Property(t => t.DeviceModel)
                .HasColumnName("DeviceModel")
                .HasMaxLength(256);
            builder.Property(t => t.IpAddress)
                .HasColumnName("IpAddress")
                .HasMaxLength(50);
            builder.Property(t => t.IsSuccessful)
                .IsRequired()
                .HasColumnName("IsSuccessful")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.FailureMessage)
                .HasColumnName("FailureMessage")
                .HasMaxLength(256);
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
            builder.HasOne(t => t.User)
                .WithMany(t => t.UserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserLogin_User_UserId");
            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.UserLogin> builder);

    }
}
