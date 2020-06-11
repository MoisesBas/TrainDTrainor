using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class UserRoleMap
        : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.UserRole>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.UserRole> builder)
        {
            // table
            builder.ToTable("tblUserRoles", "dbo");
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
            
            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasColumnName("RoleId");
            builder.Property(t => t.UserType)
               .IsRequired()
               .HasColumnName("UserType");            
            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasDefaultValueSql("((0))");
            //Relationships            
            builder.HasOne(t => t.Role)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UserRole_Role_RoleId");
            builder.HasOne(t => t.User)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_UserRole_User_UserId");

            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.UserRole> builder);

    }
}
