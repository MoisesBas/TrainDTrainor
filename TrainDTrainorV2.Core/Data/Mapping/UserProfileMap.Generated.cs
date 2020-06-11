using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class UserProfileMap
         : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.UserProfile>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.UserProfile> builder)
        {
            // table
            builder.ToTable("tblUserProfiles", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.FullName)
              .HasColumnName("FullName ")
              .HasMaxLength(256);
            builder.Property(t => t.EmailAddress)
                .IsRequired()
                .HasColumnName("EmailAddress")
                .HasMaxLength(256);
            builder.Property(t => t.MobilePhone)
                .IsRequired()
                .HasColumnName("MobilePhone")
                .HasMaxLength(50);
            builder.Property(t => t.Nationality)               
                .HasColumnName("Nationality")
                .HasMaxLength(50);
            builder.Property(t => t.Gender)
               .HasColumnName("Gender")
               .HasMaxLength(10);
            builder.Property(t => t.Age)
               .HasColumnName("Age")
               .HasMaxLength(10);
            builder.Property(t => t.Country)                
                .HasColumnName("Country ")
                .HasMaxLength(150);
            builder.Property(t => t.City)              
               .HasColumnName("City ")
               .HasMaxLength(190);
            builder.Property(t => t.JobTitle)
               .HasColumnName("JobTitle")
               .HasMaxLength(256);
            builder.Property(t => t.BusinessPhone)
               .HasColumnName("BusinessPhone")
               .HasMaxLength(50);
            builder.Property(t => t.FileId)
               .HasColumnName("FileId");            
            builder.Property(t => t.MongoDbProfileCVId)
               .HasColumnName("MongoDbProfileCVId")
               .HasMaxLength(90);         
            builder.Property(t => t.UserId)
                .IsRequired()
                .HasColumnName("UserId");
            builder.Property(t => t.IsPaid)
                .HasColumnName("IsPaid");
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

            builder.HasOne(t => t.User)
               .WithOne(t => t.UserProfiles)
               .HasForeignKey<UserProfile>(d => d.UserId)
               .HasConstraintName("FK_UserProfiles_User_UserId");           
            
            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.UserProfile> builder);

    }
}
