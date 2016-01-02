using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SaleLeadMap : EntityTypeConfiguration<SaleLead>
    {
        public SaleLeadMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SaleLead");
            this.Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.StateId).HasColumnName("StateId");
            this.Property(t => t.SaleId).HasColumnName("SaleId");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.Timestamp).HasColumnName("Timestamp").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.SaleLeads)
                .HasForeignKey(d => d.CustomerId);
            this.HasRequired(t => t.SaleLeadState)
                .WithMany(t => t.SaleLeads)
                .HasForeignKey(d => d.StateId);

            this.HasRequired(t => t.Sale)
                .WithMany(t => t.SaleLeads)
                .HasForeignKey(t => t.SaleId)
                .WillCascadeOnDelete(false);

        }
    }
}
