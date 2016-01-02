using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class Position_TrainingMap : EntityTypeConfiguration<Position_Training>
    {
        public Position_TrainingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Position_Training");
            this.Property(t => t.Id).HasColumnName("Id");

            
        }
    }
}
