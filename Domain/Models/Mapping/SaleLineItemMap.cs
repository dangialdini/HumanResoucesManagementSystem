using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Models.Mapping
{
    public class SaleLineItemMap : EntityTypeConfiguration<SaleLineItem>
    {
        public SaleLineItemMap()
        {
            this.HasKey(t => t.Id);

            this.Property(t => t.Qty)
                .IsRequired();

            this.Property(t => t.Amount)
                .IsRequired();

            this.ToTable("SaleLineItem");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.Qty).HasColumnName("Qty");
            this.Property(t => t.Amount).HasColumnName("Amount");

            this.HasRequired(t => t.Product)
               .WithMany()
               .HasForeignKey(d => d.ProductId)
               .WillCascadeOnDelete(false);

        }
    }
}
