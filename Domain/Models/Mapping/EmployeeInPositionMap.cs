using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class EmployeeInPositionMap : EntityTypeConfiguration<EmployeeInPosition>
    {
        public EmployeeInPositionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);



            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            // Properties
            // Table & Column Mappings
            this.ToTable("EmployeeInPosition");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EmployeeId).HasColumnName("EmployeeId");
            this.Property(t => t.PositionId).HasColumnName("PositionId");
            this.Property(t => t.Active).HasColumnName("Active");

            // Relationships
            this.HasMany(t => t.States)
                .WithMany(t => t.EmployeeInPositions)
                .Map(m =>
                    {
                        m.ToTable("PositionInState");
                        m.MapLeftKey("EmployeeInPositionId");
                        m.MapRightKey("StateId");
                    });

            this.HasRequired(t => t.Employee)
                .WithMany(t => t.EmployeeInPositions)
                .HasForeignKey(d => d.EmployeeId);
            this.HasRequired(t => t.Position)
                .WithMany(t => t.EmployeeInPositions)
                .HasForeignKey(d => d.PositionId);

        }
    }
}
