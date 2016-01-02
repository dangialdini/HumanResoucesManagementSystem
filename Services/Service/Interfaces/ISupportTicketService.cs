using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using SharpRepository.Repository.Queries;

namespace Services.Service.Interfaces
{
    public interface ISupportTicketService
    {
        SupportTicket CreateTicket(int siteId, int ticketStateId, int priority, DateTime timestamp, string description);

        SupportTicket UpdateTicket(int id, int siteId, int ticketStateId, int priority, DateTime timestamp, string description);

        void DeleteTicket(int id);

        IQueryable<SupportTicket> AsQueryable();

    }
}
