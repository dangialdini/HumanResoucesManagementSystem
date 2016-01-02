using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class TicketAssignmentAction
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public string Notes { get; set; }
        public System.DateTime Timestamp { get; set; }
        public virtual SupportTicketAssignment SupportTicketAssignment { get; set; }
    }
}
