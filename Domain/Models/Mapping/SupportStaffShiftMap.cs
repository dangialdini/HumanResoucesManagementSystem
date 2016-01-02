using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SupportStaffShiftMap : EntityTypeConfiguration<SupportStaffShift>
    {

        public SupportStaffShiftMap()
        {
            //Primary Key
            this.HasKey(t => t.Id);

            //Properties

            //Table & Column Mapping
            this.ToTable("SupportStaffShift");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmployeeInSupportPositionId).HasColumnName("EmployeeInSupportPositionId");            
            this.Property(t => t.StartTime).HasColumnName("StartTime");
            this.Property(t => t.EndTime).HasColumnName("EndTime");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Title).HasColumnName("Title").IsOptional();
            this.Property(t => t.Color).HasColumnName("Color").IsOptional();
            this.Property(t => t.IsAllDay).HasColumnName("IsAllDay").IsOptional();
            this.Property(t => t.RecurrenceId).HasColumnName("RecurrenceId").IsOptional();
            this.Property(t => t.RecurrenceException).HasColumnName("RecurrenceException").IsOptional();
            this.Property(t => t.RecurrenceRule).HasColumnName("RecurrenceRule").IsOptional();
            this.Property(t => t.StartTimezone).HasColumnName("StartTimezone").IsOptional();
            this.Property(t => t.EndTimezone).HasColumnName("EndTimezone").IsOptional();

            // Relationships
            this.HasRequired(t => t.EmployeeInSupportPosition)
                .WithMany(t => t.SupportStaffShift)
                .HasForeignKey(d => d.EmployeeInSupportPositionId);
        }
    }
}
