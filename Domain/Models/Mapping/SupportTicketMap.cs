using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SupportTicketMap : EntityTypeConfiguration<SupportTicket>
    {
        public SupportTicketMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("SupportTicket");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TicketStateId).HasColumnName("TicketStateId");
            this.Property(t => t.SiteId).HasColumnName("SiteId");
            this.Property(t => t.Priority).HasColumnName("Priority");
            this.Property(t => t.Timestamp).HasColumnName("Timestamp");
            this.Property(t => t.Description).HasColumnName("Description");

            // Relationships
            this.HasRequired(t => t.Site)
                .WithMany(t => t.SupportTickets)
                .HasForeignKey(d => d.SiteId);
            this.HasRequired(t => t.TicketState)
                .WithMany(t => t.SupportTickets)
                .HasForeignKey(d => d.TicketStateId);

        }
    }
}
