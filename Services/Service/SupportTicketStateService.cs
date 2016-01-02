using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class SupportTicketStateService : ISupportTicketStateService
    {
        private readonly ITicketStateRepository _repoSupportTicketState;
        public SupportTicketStateService(ITicketStateRepository repoSupportTicketState)
        {
            _repoSupportTicketState = repoSupportTicketState;
        }

        public IQueryable<TicketState> AsQueryable()
        {
            return _repoSupportTicketState.AsQueryable();
        }
    }
}
