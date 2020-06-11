using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class EmailTemplateMap
       : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.EmailTemplate>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> builder)
        {
            // table
            builder.ToTable("tblEmailTemplates", "dbo");

            // keys
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Key)
                .IsRequired()
                .HasColumnName("Key")
                .HasMaxLength(100);
            builder.Property(t => t.FromAddress)
                .IsRequired()
                .HasColumnName("FromAddress")
                .HasMaxLength(256);
            builder.Property(t => t.FromName)
                .IsRequired()
                .HasColumnName("FromName")
                .HasMaxLength(256);
            builder.Property(t => t.ReplyToAddress)
                .HasColumnName("ReplyToAddress")
                .HasMaxLength(256);
            builder.Property(t => t.ReplyToName)
                .HasColumnName("ReplyToName")
                .HasMaxLength(256);
            builder.Property(t => t.Subject)
                .HasColumnName("Subject");
            builder.Property(t => t.TextBody)
                .HasColumnName("TextBody");
            builder.Property(t => t.HtmlBody)
                .HasColumnName("HtmlBody");

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

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.EmailTemplate> builder);

    }
}
