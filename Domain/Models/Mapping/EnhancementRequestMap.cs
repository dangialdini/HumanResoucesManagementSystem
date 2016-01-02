using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class EnhancementRequestMap : EntityTypeConfiguration<EnhancementRequest>
    {
        public EnhancementRequestMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("EnhancementRequest");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.OutcomeId).HasColumnName("OutcomeId");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.EnhancementRequests)
                .HasForeignKey(d => d.CustomerId);
            this.HasRequired(t => t.EnhanceRequestOutcome)
                .WithMany(t => t.EnhancementRequests)
                .HasForeignKey(d => d.OutcomeId);

        }
    }
}
