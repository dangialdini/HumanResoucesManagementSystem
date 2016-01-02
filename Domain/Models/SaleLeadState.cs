using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class SaleLeadState
    {
        public SaleLeadState()
        {
            this.SaleLeads = new List<SaleLead>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SaleLead> SaleLeads { get; set; }
    }
}
