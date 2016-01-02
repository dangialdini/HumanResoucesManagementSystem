using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class Task_DevelopmentMap : EntityTypeConfiguration<Task_Development>
    {
        public Task_DevelopmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Task_Development");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProjectId).HasColumnName("ProjectId");
            this.Property(t => t.DeveloperId).HasColumnName("DeveloperId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Start).HasColumnName("Start");
            this.Property(t => t.Finish).HasColumnName("Finish");

            // Relationships
            this.HasMany(t => t.Task_Development1)
                .WithMany(t => t.Task_Development2)
                .Map(m =>
                    {
                        m.ToTable("Task_Parent");
                        m.MapLeftKey("ParentId");
                        m.MapRightKey("ChildId");
                    });

            this.HasRequired(t => t.EmployeeInDevelopmentPosition)
                .WithMany(t => t.Task_Development)
                .HasForeignKey(d => d.DeveloperId);
            this.HasRequired(t => t.Project_Development)
                .WithMany(t => t.Task_Development)
                .HasForeignKey(d => d.ProjectId)
                .WillCascadeOnDelete(false);

        }
    }
}
