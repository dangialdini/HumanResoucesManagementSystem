using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class TrainingMap : EntityTypeConfiguration<Training>
    {
        public TrainingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("Training");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TrainingTypeId).HasColumnName("TrainingTypeId");
            this.Property(t => t.RatePerHour).HasColumnName("RatePerHour");

            // Relationships
            this.HasRequired(t => t.TrainingType)
                .WithMany(t => t.Trainings)
                .HasForeignKey(d => d.TrainingTypeId);

        }
    }
}
