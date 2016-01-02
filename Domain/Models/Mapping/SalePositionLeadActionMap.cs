using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SalePositionLeadActionMap : EntityTypeConfiguration<SalePositionLeadAction>
    {
        public SalePositionLeadActionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Notes)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("SalePositionLeadAction");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SalePositionLeadId).HasColumnName("SalePositionLeadId");
            this.Property(t => t.Timestamp).HasColumnName("Timestamp");
            this.Property(t => t.NextContactDate).HasColumnName("NextContactDate");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.EndContact).HasColumnName("EndContact");
            this.Property(t => t.IsAllDay).HasColumnName("IsAllDay");
            this.Property(t => t.Frequency).HasColumnName("Frequency");

            // Relationships
            this.HasRequired(t => t.SalePositionLead)
                .WithMany(t => t.SalePositionLeadActions)
                .HasForeignKey(d => d.SalePositionLeadId);

        }
    }
}
