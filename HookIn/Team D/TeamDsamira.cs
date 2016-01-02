using Domain.Models;
using Services.Repositories;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_D
{
    class TeamDsamira
    {
        readonly HRMSDBContext db = new HRMSDBContext();

        public SupportTicket CreateNewTicket(int SiteId, int StateId, string Description, int Priority)
        {
            ISupportTicketRepository repoSupportTicket = new SupportTicketRepository(db);
            var supportTicket = new SupportTicket { SiteId = SiteId, TicketStateId = StateId, Description = Description, Priority = Priority, Timestamp = DateTime.Now };
            repoSupportTicket.Add(supportTicket);         

            return supportTicket;
        }


        public SupportTicketAssignment CreateNewTicketAssigment(int TicketId, int EmployeeId)
        {
            ISupportTicketAssignmentRepository repoSupportTicketAssignment = new SupportTicketAssignmentRepository(db);
            var supportTicketAssignment = new SupportTicketAssignment {
                TicketId = TicketId,
                EmployeeId = EmployeeId
            };
            repoSupportTicketAssignment.Add(supportTicketAssignment);

            return supportTicketAssignment;
        }


        public void start()
        {
            //create new ticket
            SupportTicket newTicket = CreateNewTicket(0,3,"Software Bug",4);

            //create new asssignee
            SupportTicketAssignment newAssignee = CreateNewTicketAssigment(newTicket.Id, 1);
            

        }

    }
}