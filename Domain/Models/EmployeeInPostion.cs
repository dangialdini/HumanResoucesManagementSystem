using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public  partial class EmployeeInPosition
    {



        public enum PositionType { Development, Sales, Support, Training };


        public EmployeeInPosition()
        {
            this.SupportTicketAssignments = new List<SupportTicketAssignment>();
            this.States = new List<State>();
        }



        public virtual PositionType Role
        {
            get
            {
                throw new ArgumentException();
            }
        }

        

        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public bool Active { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }
        public virtual ICollection<SupportTicketAssignment> SupportTicketAssignments { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
