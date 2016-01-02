using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class Project_DevelopmentMap : EntityTypeConfiguration<Project_Development>
    {
        public Project_DevelopmentMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Project_Development");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.EnhancementRequestId).HasColumnName("EnhancementRequestId");
            this.Property(t => t.ManagerId).HasColumnName("ManagerId");
            this.Property(t => t.Start).HasColumnName("Start");
            this.Property(t => t.Finish).HasColumnName("Finish");

            // Relationships
            this.HasRequired(t => t.EmployeeInDevelopmentPosition)
                .WithMany(t => t.Project_Development)
                .HasForeignKey(d => d.ManagerId);
            this.HasRequired(t => t.EnhancementRequest)
                .WithMany(t => t.Project_Development)
                .HasForeignKey(d => d.EnhancementRequestId);

        }
    }
}
