using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{

    public partial class TrainingVideoPicMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TrainingVideoPic>
    {
        public void Configure(EntityTypeBuilder<TrainingVideoPic> builder)
        {
            builder.ToTable("TrainingVideoPic_View", "dbo");
            builder.HasKey(t => t.Stream_id);
            // Properties
            builder.Property(t => t.Stream_id)
                .IsRequired()
                .HasColumnName("Stream_id")
                .HasDefaultValueSql("(newsequentialid())")
                .ValueGeneratedOnAdd();
            builder.Property(t => t.File_stream)
               .HasColumnName("File_stream");
            builder.Property(t => t.Name)
              .HasColumnName("Name");
            builder.Property(t => t.Path)
             .HasColumnName("Path");
            builder.Property(t => t.ParentPath)
            .HasColumnName("ParentPath");
            builder.Property(t => t.Creation_time)
           .HasColumnName("Creation_time");
            builder.Property(t => t.Last_write_time)
           .HasColumnName("Last_write_time");
            builder.Property(t => t.Last_access_time)
          .HasColumnName("Last_access_time");
            builder.Property(t => t.Is_directory)
         .HasColumnName("Is_directory");
            builder.Property(t => t.Is_offline)
       .HasColumnName("Is_offline");
            builder.Property(t => t.Is_hidden)
      .HasColumnName("Is_hidden");
            builder.Property(t => t.Is_readonly)
    .HasColumnName("Is_readonly");
            builder.Property(t => t.Is_archive)
   .HasColumnName("Is_archive");
            builder.Property(t => t.Is_system)
  .HasColumnName("Is_system");

            builder.Property(t => t.Is_temporary)
  .HasColumnName("Is_temporary");
            builder.Property(t => t.fullpath)
 .HasColumnName("fullpath");
            builder.Property(t => t.Id)
.HasColumnName("Id");
            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TrainingVideoPic> builder);

    }
}
