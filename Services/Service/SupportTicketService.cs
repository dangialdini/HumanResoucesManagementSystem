using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;

namespace Services.Service
{
    public class SupportTicketService : ISupportTicketService
    {
        private readonly ISupportTicketRepository _repoSupportTicket;

        public SupportTicketService(ISupportTicketRepository repoSupportTicket)
        {
            _repoSupportTicket = repoSupportTicket;
        }

        public SupportTicket CreateTicket(int siteId, int ticketStateId, int priority, DateTime timestamp, string description)
        {
            var ticket = new SupportTicket
            {
                SiteId = siteId,
                TicketStateId = ticketStateId,
                Description = description,
                Priority = priority,
                Timestamp = timestamp
            };
            try
            {
                _repoSupportTicket.Add(ticket);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessage = ex.EntityValidationErrors
                    .SelectMany(x => x.ValidationErrors)
                    .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessage);
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (Exception)
            {
                throw;
            }

            return ticket;
        }

        public SupportTicket UpdateTicket(int id, int ticketStateId, int siteId, int priority, DateTime timestamp, string description)
        {
            var ticket = _repoSupportTicket.Get(id);
            ticket.SiteId = siteId;
            ticket.TicketStateId = ticketStateId;
            ticket.Priority = priority;
            ticket.Timestamp = timestamp;
            ticket.Description = description;
            try
            {
                _repoSupportTicket.Update(ticket);
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("; ", errorMessages);
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }

            return ticket;
        }

        public void DeleteTicket(int id)
        {
            var ticket = _repoSupportTicket.Get(id);
            _repoSupportTicket.Delete(ticket);
        }

        public IQueryable<SupportTicket> AsQueryable()
        {
            return _repoSupportTicket.AsQueryable();
        }

    }
}
