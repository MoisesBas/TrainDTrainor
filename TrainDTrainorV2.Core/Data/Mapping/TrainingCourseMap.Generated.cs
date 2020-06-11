using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainDTrainorV2.Core.Data.Entities;

namespace TrainDTrainorV2.Core.Data.Mapping
{
    public partial class TrainingCourseMap : Microsoft.EntityFrameworkCore.IEntityTypeConfiguration<TrainDTrainorV2.Core.Data.Entities.TrainingCourse>
    {
        public void Configure(EntityTypeBuilder<TrainingCourse> builder)
        {
            builder.ToTable("tblTrainingCourses", "dbo");
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
               .HasColumnName("Description")
               .HasMaxLength(256);
            builder.Property(t => t.Objectives)
               .HasColumnName("Objectives")
               .HasMaxLength(256);
            builder.Property(t => t.TrainorId)
              .HasColumnName("TrainorId");
            builder.Property(t => t.CalendarYear)
              .IsRequired()
              .HasColumnName("CalendarYear")
              .HasDefaultValueSql("(datepart(year,getdate()))");
            builder.Property(t => t.From)
               .IsRequired()
               .HasColumnName("From");
            builder.Property(t => t.To)
              .IsRequired()
              .HasColumnName("To");
            builder.Property(t => t.Address)
              .HasColumnName("Address")
              .HasMaxLength(256);
            builder.Property(t => t.LocationMap)
             .HasColumnName("LocationMap")
             .HasMaxLength(256);
            builder.Property(t => t.MaxAttendee)
             .HasColumnName("MaxAttendee")
             .HasDefaultValueSql("((0))");
            builder.Property(t => t.NoAttendee)
            .HasColumnName("NoAttendee")
            .HasDefaultValueSql("((0))");
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

            //relationship
            builder.HasOne(t => t.Trainor)
              .WithMany(t => t.UserCourses)
              .HasForeignKey(d => d.TrainorId)
              .HasConstraintName("FK_UserCourses_Trainor_TrainorId");

            builder.HasOne(t => t.Training)
             .WithMany(t => t.TrainingCourses)
             .HasForeignKey(d => d.TrainingId)
             .HasConstraintName("FK_TrainingCourses_Training_TrainingId");

            InitializeMapping(builder);
        }
        partial void InitializeMapping(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TrainDTrainorV2.Core.Data.Entities.TrainingCourse> builder);
    }
}
