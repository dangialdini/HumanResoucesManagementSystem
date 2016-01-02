using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class Position_SalesMap : EntityTypeConfiguration<Position_Sales>
    {
        public Position_SalesMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Position_Sales");
            this.Property(t => t.Id).HasColumnName("Id");

            
        }
    }
}
