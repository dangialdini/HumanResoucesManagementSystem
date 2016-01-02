using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace UI.Api
{
    public class SupportTicketStatesController : ApiController
    {
        private readonly ISupportTicketStateService _supportTicketStateService;

        public SupportTicketStatesController(ISupportTicketStateService supportTicketStateService)
        {
            _supportTicketStateService = supportTicketStateService;
        }

        [HttpGet]
        public IHttpActionResult GetTicketState()
        {
            var query = _supportTicketStateService.AsQueryable();
            var result = query
                .Select(s => new
                {
                    s.Id,
                    s.Name
                }).ToList();
            return Ok(result);
        }

    }
}
