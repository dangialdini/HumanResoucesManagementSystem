using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class SalePositionLeadAction
    {
        public int Id { get; set; }
        public int SalePositionLeadId { get; set; }
        public System.DateTime Timestamp { get; set; }
        public System.DateTime NextContactDate { get; set; }
        public string Notes { get; set; }
        public virtual SalePositionLead SalePositionLead { get; set; }
        public DateTime EndContact { get; set; }
        public bool IsAllDay { get; set; }
        public string Frequency { get; set; }
    }
}
