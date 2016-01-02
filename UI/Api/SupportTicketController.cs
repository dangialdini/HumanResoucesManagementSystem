using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Services.Service.Interfaces;
using UI.Areas.Support.Models;
using System.Web.Http.ModelBinding;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Runtime.Serialization;

namespace UI.Api
{
    public class SupportTicketController : ApiController
    {
        private readonly ISupportTicketService _supportTicketService;

        public SupportTicketController(ISupportTicketService supportTicketService)
        {
            _supportTicketService = supportTicketService;
        }

        [HttpGet]
        public IHttpActionResult GetTicket([ModelBinder(typeof(Kendo.Mvc.UI.WebApiDataSourceRequestModelBinder))] DataSourceRequest request)
        {
            var tickets = _supportTicketService.AsQueryable();
            var viewModel = tickets.ToDataSourceResult(request, t => new SupportTicketGridViewModel
            {
                Id = t.Id,
                SiteId = t.SiteId,
                TicketState = new TicketStateViewModel() { Id = t.TicketState.Id, Name = t.TicketState.Name },
                Site = new SiteViewModel() { Id = t.Site.Id, Name = t.Site.Name },
                Priority = t.Priority,
                Timestamp = t.Timestamp,
                Description = t.Description
            });
            return Ok(viewModel);
        }

        [HttpPost]

        public IHttpActionResult PostTicket(SupportTicketGridViewModel model)
        {
            var ticket = _supportTicketService.CreateTicket(
                model.Site.Id,
                model.TicketState.Id,
                model.Priority,
                model.Timestamp,
                model.Description);
            return Ok(new { Data = model });
        }

        [HttpPut]
        public IHttpActionResult PutTicket(SupportTicketGridViewModel model)
        {
            var ticket = _supportTicketService.AsQueryable().FirstOrDefault(t => t.Id == model.Id);

            if (ticket == null)
            {
                return NotFound();
            }
            var result = _supportTicketService.UpdateTicket(
                model.Id,
                model.TicketState.Id,
                model.Site.Id,
                model.Priority,
                model.Timestamp,
                model.Description);
            model.Id = ticket.Id;
            return Ok(new { Data = model });
        }

        [HttpDelete]
        public IHttpActionResult DeleteTicket(SupportTicketGridViewModel model)
        {
            try
            {
                _supportTicketService.DeleteTicket(model.Id);
            }
            catch (Exception ex)
            {
                throw new NullReferenceException(ex.Message);
            }
            return Ok(new { Data = model });
        }
    }
}
