using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class TicketAssignmentActionMap : EntityTypeConfiguration<TicketAssignmentAction>
    {
        public TicketAssignmentActionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Notes)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TicketAssignmentAction");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AssignmentId).HasColumnName("AssignmentId");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Timestamp).HasColumnName("Timestamp");

            // Relationships
            this.HasRequired(t => t.SupportTicketAssignment)
                .WithMany(t => t.TicketAssignmentActions)
                .HasForeignKey(d => d.AssignmentId);

        }
    }
}
