using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class OfficeMap : EntityTypeConfiguration<Office>
    {
        public OfficeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CompanyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AddressId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Office");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.AddressId).HasColumnName("AddressId");

            // Relationships
            this.HasRequired(t => t.Address)
                .WithMany(t => t.Offices)
                .HasForeignKey(d => d.AddressId);

            this.HasRequired(t => t.Company)
                .WithMany(t => t.Offices)
                .HasForeignKey(d => d.CompanyId);
        }
    }
}

