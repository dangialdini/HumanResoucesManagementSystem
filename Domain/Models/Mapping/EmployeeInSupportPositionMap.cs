using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class EmployeeInSupportPositionMap : EntityTypeConfiguration<EmployeeInSupportPosition>
    {
        public EmployeeInSupportPositionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            //this.Property(t => t.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("EmployeeInSupportPosition");
            this.Property(t => t.Id).HasColumnName("Id");

          

        }
    }
}
