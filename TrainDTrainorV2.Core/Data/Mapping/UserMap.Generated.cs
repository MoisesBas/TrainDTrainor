using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class UserMap
       : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.User>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.User> builder)
        {
            // table
            builder.ToTable("tblUsers", "dbo");
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
            builder.Property(t => t.IsEmailAddressConfirmed)
                .IsRequired()
                .HasColumnName("IsEmailAddressConfirmed")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.PhoneNumber)
               .IsRequired()
               .HasColumnName("PhoneNumber")
               .HasMaxLength(15);
            builder.Property(t => t.IsPhoneNumberConfirmed)
                .IsRequired()
                .HasColumnName("IsPhoneNumberConfirmed")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.DisplayName)
                .IsRequired()
                .HasColumnName("DisplayName")
                .HasMaxLength(256);
            builder.Property(t => t.PasswordHash)
                .HasColumnName("PasswordHash");
            builder.Property(t => t.ResetHash)
                .HasColumnName("ResetHash");
            builder.Property(t => t.InviteHash)
                .HasColumnName("InviteHash");
            builder.Property(t => t.AccessFailedCount)
                .IsRequired()
                .HasColumnName("AccessFailedCount")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.LockoutEnabled)
                .IsRequired()
                .HasColumnName("LockoutEnabled")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.LockoutEnd)
                .HasColumnName("LockoutEnd");
            builder.Property(t => t.LastLogin)
                .HasColumnName("LastLogin");            
            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.IsGlobalAdministrator)
                .IsRequired()
                .HasColumnName("IsGlobalAdministrator")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.IsAgree)
               .IsRequired()
               .HasColumnName("IsAgree")
               .HasDefaultValueSql("((0))");
            builder.Property(t => t.OTP)               
               .HasColumnName("OTP")
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
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.User> builder);

    }
}
