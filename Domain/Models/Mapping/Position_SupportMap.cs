using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class Position_SupportMap : EntityTypeConfiguration<Position_Support>
    {
        public Position_SupportMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Position_Support");
            this.Property(t => t.Id).HasColumnName("Id");

      
        }
    }
}
