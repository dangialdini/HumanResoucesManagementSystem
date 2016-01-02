using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class TrainingSessionMap : EntityTypeConfiguration<TrainingSession>
    {
        public TrainingSessionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TrainingSession");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SiteId).HasColumnName("SiteId");
            this.Property(t => t.TrainingId).HasColumnName("TrainingId");
            this.Property(t => t.EmployeeTrainerId).HasColumnName("EmployeeTrainerId");
            this.Property(t => t.Start).HasColumnName("Start");
            this.Property(t => t.DurationInMinutes).HasColumnName("DurationInMinutes");
            this.Property(t => t.Delivered).HasColumnName("Delivered");

            // Relationships
            this.HasOptional(t => t.EmployeeInTrainingPostion)
                .WithMany(t => t.TrainingSessions)
                .HasForeignKey(d => d.EmployeeTrainerId);
            this.HasRequired(t => t.Site)
                .WithMany(t => t.TrainingSessions)
                .HasForeignKey(d => d.SiteId);
            this.HasRequired(t => t.Training)
                .WithMany(t => t.TrainingSessions)
                .HasForeignKey(d => d.TrainingId);

        }
    }
}
