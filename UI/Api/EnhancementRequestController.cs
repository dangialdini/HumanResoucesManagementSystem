using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UI.Areas.Development.Models;
using System.Data.Entity;

namespace UI.Api
{
    public class EnhancementRequestController : ApiController
    {
        private readonly IEnhancementRequestService _serviceEnhancementRequest;
        private readonly IEnhancementRequestOutcomeRepository _repoEnhancementRequestOutcome;
        private readonly IEnhancementRequestRepository _repoEnhancementRequest;
        private readonly ICustomerRepository _repoCustomer;

        public EnhancementRequestController() { }

        public EnhancementRequestController(IEnhancementRequestRepository repoEnhancementRequest,
            IEnhancementRequestService serviceEnhancementRequest,
            IEnhancementRequestOutcomeRepository repoEnhancementRequestOutcome,
            ICustomerRepository repoCustomer)
        {
            _repoEnhancementRequest = repoEnhancementRequest;
            _serviceEnhancementRequest = serviceEnhancementRequest;
            _repoEnhancementRequestOutcome = repoEnhancementRequestOutcome;
            _repoCustomer = repoCustomer;
        }



        [Route("api/enhancementRequestOutcomes")]
        [HttpGet]
        public IHttpActionResult GetEnhancementRequestOutcomes()
        {
            var model = _repoEnhancementRequestOutcome.AsQueryable()
                .Select(o => new
                {
                    Id = o.Id,
                    Result = o.Result
                }).ToList();

            return Ok(model);
        }
        [Route("api/enhancementRequestCustomers")]
        [HttpGet]
        public IHttpActionResult GetEnhancementRequestCustomers()
        {
            var model = _repoCustomer.AsQueryable()
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name

                }).ToList();

            return Ok(model);
        }

        // For get, because the user generally isn't sending data back, we can have a parameterless method.
        // Except in cases where we need information for stuff like searching
        [HttpGet]
        public IHttpActionResult GetEnhancementRequest()
        {
            var results = _serviceEnhancementRequest.AsQueryable().Select(e => new EnhancementRequestViewModel
            {
                Id = e.Id,
                Customer = new CustomerIdViewModel() { Id = e.Customer.Id, Name = e.Customer.Name },
                Description = e.Description,
                Outcome = new OutcomeViewModel() { Id = e.EnhanceRequestOutcome.Id, Result = e.EnhanceRequestOutcome.Result },
                Weight = e.Weight,
                Timestamp = e.Timestamp
            });

            return Ok(results.ToList());

        }


        [HttpPost]
        public IHttpActionResult PostEnhancementRequest(EnhancementRequestViewModel model)
        {
            var request = _serviceEnhancementRequest.CreateRequest(model.Customer.Id, model.Description, model.Weight, model.Outcome.Id, Convert.ToDateTime(model.Timestamp));
            model.Id = request.Id;
            return Created(Request.RequestUri + model.Id.ToString(), model);
        }

        [HttpPost]
        public IHttpActionResult ReviewRequest(int enhancementRequestId, int outcomeId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _serviceEnhancementRequest.UpdateEnhancementRequestOutcome(enhancementRequestId, outcomeId);
            return Ok(result);

        }

        //var query = _serviceEnhancementRequest.AsQueryable()
        //    .Where(r => r.CustomerId > 1)
        //    .OrderBy(r => r.Id)
        //    .ThenBy(r => r.OutcomeId)
        //    .Skip(10).Take(15)
        //    .Select(r => new { r.Description });

        //return CreatedAtRoute("DefaultApi", new { id = enhancementRequest.Id }, enhancementRequest);


        [ResponseType(typeof(EnhancementRequestViewModel))]
        public IHttpActionResult PutEnhancementRequest(EnhancementRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _serviceEnhancementRequest.UpdateRequest(model.Id, model.Customer.Id, model.Description, model.Weight, model.Outcome.Id, Convert.ToDateTime(model.Timestamp));

            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [ResponseType(typeof(EnhancementRequestViewModel))]
        public IHttpActionResult DeleteEnhancementRequest(EnhancementRequestViewModel model)
        {
            _serviceEnhancementRequest.DeleteRequest(model.Id);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


    }
}
