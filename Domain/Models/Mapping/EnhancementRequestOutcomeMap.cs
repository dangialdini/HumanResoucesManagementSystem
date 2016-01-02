using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class EnhancementRequestOutcomeMap : EntityTypeConfiguration<EnhancementRequestOutcome>
    {
        public EnhancementRequestOutcomeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Result)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EnhancementRequestOutcome");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Result).HasColumnName("Result");
        }
    }
}
