using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class PaymentTransactionHistoryMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.PaymentTransactionHistory>
    {
        public void Configure(EntityTypeBuilder<PaymentTransactionHistory> builder)
        {
            builder.ToTable("tblPaymentTransactionHistory", "dbo");

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
            builder.Property(t => t.CourseId)
              .IsRequired()
              .HasColumnName("CourseId");
            builder.Property(t => t.PaymentTransactionId)
             .IsRequired()
             .HasColumnName("PaymentTransactionId");
            builder.Property(t => t.FileId)
                .IsRequired()
                .HasColumnName("FileId");
            builder.Property(t => t.PaymentDate)
               .IsRequired()
               .HasColumnName("PaymentDate");
            builder.Property(t => t.Amount)
               .IsRequired()
               .HasColumnName("Amount");
            builder.Property(t => t.Status)
                .HasColumnName("Status");
            builder.Property(t => t.Comments)
                .HasColumnName("Comments");
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

            builder.HasOne(t => t.PaymentTransaction)
             .WithMany(t => t.PaymentTransactionHistories)
             .HasForeignKey(d => d.PaymentTransactionId)
             .HasConstraintName("FK_PaymentTransaction_PaymentTransactionHistories_PaymentTransactionId");
            
            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.PaymentTransactionHistory> builder);
    }
}
