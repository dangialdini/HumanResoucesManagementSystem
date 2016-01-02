using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public partial class Sale
    {

        public Sale()
        {
            this.SaleLineItems = new List<SaleLineItem>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int OrderNumber { get; set; }
        public virtual ICollection<SaleLead> SaleLeads { get; set; }
        public virtual ICollection<SaleLineItem> SaleLineItems { get; set; }

    }
}
