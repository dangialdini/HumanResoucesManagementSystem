using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class TicketState
    {
        public TicketState()
        {
            this.SupportTickets = new List<SupportTicket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SupportTicket> SupportTickets { get; set; }
    }
}
