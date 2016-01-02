using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Sales
{
    public class SalesKPIViewModel
    {
        public DateTime Date { get; set; }
        public decimal GrossProfit { get; set; }
        public SaleEmployeeViewModel Employee { get; set; }
        public int TotalSales { get; set; }
        public int TotalLeads { get; set; }
        public SaleCustomerViewModel Customer { get; set; }
    }
}