using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SalePositionLeadMap : EntityTypeConfiguration<SalePositionLead>
    {
        public SalePositionLeadMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("SalePositionLead");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmployeeInSalePostionId).HasColumnName("EmployeeInSalePostionId");
            this.Property(t => t.SaleLeadId).HasColumnName("SaleLeadId");
            this.Property(t => t.FinalisedSale).HasColumnName("FinalisedSale");

            // Relationships
            this.HasRequired(t => t.EmployeeInSalePosition)
                .WithMany(t => t.SalePositionLeads)
                .HasForeignKey(d => d.EmployeeInSalePostionId);
            this.HasRequired(t => t.SaleLead)
                .WithMany(t => t.SalePositionLeads)
                .HasForeignKey(d => d.SaleLeadId);

        }
    }
}
