using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class SupportTicket
    {
        public SupportTicket()
        {
            this.SupportTicketAssignments = new List<SupportTicketAssignment>();
        }

        public int Id { get; set; }
        public int TicketStateId { get; set; }
        public int SiteId { get; set; }
        public int Priority { get; set; }
        public System.DateTime Timestamp { get; set; }
        public string Description { get; set; }
        public virtual Site Site { get; set; }
        public virtual TicketState TicketState { get; set; }
        public virtual ICollection<SupportTicketAssignment> SupportTicketAssignments { get; set; }
    }
}
