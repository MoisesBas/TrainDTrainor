using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class LevelVideoMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.LevelVideo>
    {
        public void Configure(EntityTypeBuilder<LevelVideo> builder)
        {
            builder.ToTable("tblLevelVideos", "dbo");
            // keys
            builder.HasKey(t => t.Id);
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.LevelId)
               .IsRequired()
               .HasColumnName("LevelId");            
            builder.Property(t => t.Name)
               .IsRequired()
               .HasColumnName("Name")
               .HasMaxLength(256);
            builder.Property(t => t.Description)
               .HasColumnName("Description")
               .HasMaxLength(256);
            builder.Property(t => t.FileId)           
              .HasColumnName("FileId");              
            builder.Property(t => t.IsDeleted)
                .IsRequired()
                .HasColumnName("IsDeleted")
                .HasDefaultValueSql("((0))");
            builder.Property(t => t.IsMobile)
               .HasColumnName("IsMobile")
               .HasDefaultValueSql("((0))");
            builder.Property(t => t.IsDesktop)
              .HasColumnName("IsDesktop")
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
            builder.HasOne(t => t.Level)
             .WithMany(t => t.LevelVideos)
             .HasForeignKey(d => d.LevelId)
             .HasConstraintName("FK_LevelVideos_Level_LevelId");           
            InitializeMapping(builder);

        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.LevelVideo> builder);
    }
}
