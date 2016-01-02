using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Street1)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Street2)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Street1).HasColumnName("Street1");
            this.Property(t => t.Street2).HasColumnName("Street2");
            this.Property(t => t.SuburbId).HasColumnName("SuburbId");

            // Relationships
            this.HasRequired(t => t.Suburb)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.SuburbId);

        }
    }
}
