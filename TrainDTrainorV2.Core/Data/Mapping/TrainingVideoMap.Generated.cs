using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class TrainingVideoMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TrainingVideo>
    {
        public void Configure(EntityTypeBuilder<TrainingVideo> builder)
        {
            builder.ToTable("tblTrainingVideos", "dbo");
            // keys
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasMaxLength(256);
            builder.Property(t => t.Description)
                .HasColumnName("Description");
            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.Created)
                .IsRequired()
                .HasColumnName("Created")
                .HasDefaultValueSql("(sysutcdatetime())");
            builder.Property(t => t.FileId)
               .IsRequired()
               .HasColumnName("FileId")
               .HasMaxLength(50);
            builder.Property(t => t.IsMobile)
               .HasColumnName("IsMobile")
               .HasDefaultValueSql("((0))");
            builder.Property(t => t.IsDesktop)
              .HasColumnName("IsDesktop")
              .HasDefaultValueSql("((0))");
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
            builder.HasOne(t => t.Training)
           .WithMany(t => t.TrainingVideos)
           .HasForeignKey(d => d.TrainingId)
           .HasConstraintName("FK_TrainingVideos_Training_TrainingId");
           
            InitializeMapping(builder);
        }

        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TrainingVideo> builder);
    }
}
