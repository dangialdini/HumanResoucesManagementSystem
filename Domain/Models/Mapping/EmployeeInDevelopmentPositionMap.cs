using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class EmployeeInDevelopmentPositionMap : EntityTypeConfiguration<EmployeeInDevelopmentPosition>
    {
        public EmployeeInDevelopmentPositionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            //// Properties
            //this.Property(t => t.Id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("EmployeeInDevelopmentPosition");
            this.Property(t => t.Id).HasColumnName("Id");



        }
    }
}
