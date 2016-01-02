using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class SaleLead
    {
        public SaleLead()
        {
            this.SalePositionLeads = new List<SalePositionLead>();
        }

        public int Id { get; set; }
        public int StateId { get; set; }
        public int SaleId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<System.DateTime> Timestamp { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual SaleLeadState SaleLeadState { get; set; }
        public virtual Sale Sale { get; set; }
        public virtual ICollection<SalePositionLead> SalePositionLeads { get; set; }
    }
}
