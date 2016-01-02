using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SaleMap : EntityTypeConfiguration<Sale>
    {
        public SaleMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.OrderNumber)
                .IsRequired();

            this.ToTable("Sale");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.OrderNumber).HasColumnName("OrderNumber");

            this.HasMany(t => t.SaleLineItems)
                .WithRequired()
                .HasForeignKey(t => t.SaleId)
                .WillCascadeOnDelete(false);

        }
    }
}
