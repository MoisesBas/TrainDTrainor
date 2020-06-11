using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class LevelMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("tblLevels", "dbo");
            // keys
            builder.HasKey(t => t.Id);           
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.TrainingId)
                .HasColumnName("TrainingId");
            builder.Property(t => t.Title)
               .IsRequired()
               .HasColumnName("Title")
               .HasMaxLength(256);
            builder.Property(t => t.Description)
               .HasColumnName("Description")
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

            builder.HasOne(t => t.Training)
              .WithMany(t => t.Levels)
              .HasForeignKey(d => d.TrainingId)
              .HasConstraintName("FK_Levels_Training_TrainingId");
            // Relationships           
            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.Level> builder);
    }
}
