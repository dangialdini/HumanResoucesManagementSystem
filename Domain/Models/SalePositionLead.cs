using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class SalePositionLead
    {
        public SalePositionLead()
        {
            this.SalePositionLeadActions = new List<SalePositionLeadAction>();
        }

        public int Id { get; set; }
        public int EmployeeInSalePostionId { get; set; }
        public int SaleLeadId { get; set; }
        public bool FinalisedSale { get; set; }
        public virtual EmployeeInSalePosition EmployeeInSalePosition { get; set; }
        public virtual SaleLead SaleLead { get; set; }
        public virtual ICollection<SalePositionLeadAction> SalePositionLeadActions { get; set; }
    }
}
