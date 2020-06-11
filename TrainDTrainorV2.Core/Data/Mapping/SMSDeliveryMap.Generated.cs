using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class SMSDeliveryMap
       : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.SMSDelivery>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.SMSDelivery> builder)
        {
            // table
            builder.ToTable("tblSMSDeliveries", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.IsProcessing)
                .IsRequired()
                .HasColumnName("IsProcessing")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.IsDelivered)
                .IsRequired()
                .HasColumnName("IsDelivered")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.Delivered)
                .HasColumnName("Delivered");
            builder.Property(t => t.Attempts)
                .IsRequired()
                .HasColumnName("Attempts")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.LastAttempt)
                .HasColumnName("LastAttempt");
            builder.Property(t => t.NextAttempt)
                .HasColumnName("NextAttempt");
            builder.Property(t => t.SMSLog)
                .HasColumnName("SMSLog");
            builder.Property(t => t.Error)
                .HasColumnName("Error");
            builder.Property(t => t.From)
                .HasColumnName("From")
                .HasMaxLength(265);
            builder.Property(t => t.To)
                .HasColumnName("To")
                .HasMaxLength(265);
            builder.Property(t => t.Message)
                .HasColumnName("Message")
                .HasMaxLength(265);
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
            
            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.SMSDelivery> builder);

    }
}
