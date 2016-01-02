using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class SupportTicketAssignment
    {
        public SupportTicketAssignment()
        {
            this.TicketAssignmentActions = new List<TicketAssignmentAction>();
        }

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int TicketId { get; set; }
        public virtual EmployeeInPosition EmployeeInPostion { get; set; }
        public virtual SupportTicket SupportTicket { get; set; }
        public virtual ICollection<TicketAssignmentAction> TicketAssignmentActions { get; set; }
    }
}
