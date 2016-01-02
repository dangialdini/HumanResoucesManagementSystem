using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Models.Sales
{
    public class LeadActionDTO
    {
        public int ActionId { get; set; }
        public int SalePositionLeadId { get; set; }
        public string Title { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public System.DateTime Timestamp { get; set; }

        public System.DateTime NextContactDate { get; set; }

        public string StartTimezone { get; set; }

        public System.DateTime EndContact { get; set; }
        public string EndTimezone { get; set; }

        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }

        public string RecurrenceException { get; set; }
        public SaleDTO Sale { get; set; }
        public EmployeeDTO Employee { get; set; }
    }
}
