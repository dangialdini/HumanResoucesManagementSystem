using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Contact");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.ContactTypeId).HasColumnName("ContactTypeId");

            // Relationships
            this.HasRequired(t => t.ContactType)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.ContactTypeId);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.CustomerId);
            this.HasRequired(t => t.Person)
                .WithOptional(t => t.Contact);

        }
    }
}
