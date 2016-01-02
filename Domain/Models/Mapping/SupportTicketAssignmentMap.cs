using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SupportTicketAssignmentMap : EntityTypeConfiguration<SupportTicketAssignment>
    {
        public SupportTicketAssignmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("SupportTicketAssignment");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
            this.Property(t => t.TicketId).HasColumnName("TicketId");

            // Relationships
            this.HasRequired(t => t.EmployeeInPostion)
                .WithMany(t => t.SupportTicketAssignments)
                .HasForeignKey(d => d.EmployeeId);
            this.HasRequired(t => t.SupportTicket)
                .WithMany(t => t.SupportTicketAssignments)
                .HasForeignKey(d => d.TicketId);

        }
    }
}
