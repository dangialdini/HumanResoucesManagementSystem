using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class SaleLineItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
        public int Qty { get; set; }
        public decimal Amount { get; set; }
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }

    }
}
