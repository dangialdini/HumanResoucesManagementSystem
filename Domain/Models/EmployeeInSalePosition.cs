using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmployeeInSalePosition : EmployeeInPosition
    {
        public EmployeeInSalePosition()
        {
            this.SalePositionLeads = new List<SalePositionLead>();
        }



        public virtual ICollection<SalePositionLead> SalePositionLeads { get; set; }


        public override EmployeeInPosition.PositionType Role
        {
            get { return PositionType.Sales; }
        }
    }
}
