using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SuburbMap : EntityTypeConfiguration<Suburb>
    {
        public SuburbMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Postcode)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Suburb");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.Postcode).HasColumnName("Postcode");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Latitude).HasColumnName("Latitude");
            this.Property(t => t.Longitude).HasColumnName("Longitude");
            this.Property(t => t.ZoneId).HasColumnName("ZoneId");

            // Relationships
            this.HasRequired(t => t.State)
                .WithMany(t => t.Suburbs)
                .HasForeignKey(d => d.StateId);
            this.HasRequired(t => t.Zone)
                .WithMany(t => t.Suburbs)
                .HasForeignKey(d => d.ZoneId);

        }
    }
}
