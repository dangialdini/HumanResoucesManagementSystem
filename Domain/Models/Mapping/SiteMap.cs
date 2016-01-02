using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SiteMap : EntityTypeConfiguration<Site>
    {
        public SiteMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Site");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Franchise).HasColumnName("Franchise");
            this.Property(t => t.HeadQuarters).HasColumnName("HeadQuarters");

            // Relationships
            this.HasRequired(t => t.Address)
                .WithMany(t => t.Sites)
                .HasForeignKey(d => d.AddressId);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Sites)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
