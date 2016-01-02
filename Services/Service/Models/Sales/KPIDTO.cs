using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Models.Sales
{
    public class KPIDTO
    {
        public EmployeeDTO Employee { get; set; }
        public decimal GrossProfit { get; set; }
        public int TotalSales { get; set; }
        public DateTime Date { get; set; }
        public int TotalLeads { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
