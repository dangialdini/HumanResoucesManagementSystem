using Domain.Models;
using Kendo.Mvc.UI;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using UI.Areas.Sales.Models;


namespace UI.Api
{
    public class SaleLeadsController : ApiController
    {
        private readonly ISaleLeadService _serviceSaleLead;
        private readonly IPositionService _servicePosition;
        private readonly ICustomerService _serviceCustomer;
        private readonly ICustomerRepository _repoCustomer;
        private readonly ISaleLeadStateRepository _repoSaleLeadState;

        public SaleLeadsController(ISaleLeadService serviceSaleLead, IPositionService servicePosition, ICustomerService serviceCustomer, ICustomerRepository repoCustomer, ISaleLeadStateRepository repoSaleLeadState)
        {
            _serviceSaleLead = serviceSaleLead;
            _servicePosition = servicePosition;
            _serviceCustomer = serviceCustomer;
            _repoCustomer = repoCustomer;
            _repoSaleLeadState = repoSaleLeadState;
        }

        #region saleLeadIndex
        //GET: /api/SaleLeads/Get
        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _serviceSaleLead.AsQueryable()
                .Select((lead) => new
                {
                    Id = lead.Id,
                    StateId = lead.StateId,
                    SaleLeadState = new
                    {
                        Id = lead.SaleLeadState.Id,
                        Name = lead.SaleLeadState.Name
                    },
                    CustomerId = lead.CustomerId,
                    Customer = new
                    {
                        Id = lead.Customer.Id,
                        Name = lead.Customer.Name,
                        Phone = lead.Customer.Phone,
                        Email = lead.Customer.Email

                    },
                    SaleId = lead.SaleId,

                    Timestamp = lead.Timestamp
                }).ToList();

            return Ok(result);
        }

        //POST: /api/SaleLeads/Create
        [HttpPost]
        public IHttpActionResult CreateSaleLead(SaleLead salelead)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var lead = _serviceSaleLead.CreateSaleLead(salelead.Customer.Id, salelead.SaleLeadState.Id, salelead.SaleId, Convert.ToDateTime(salelead.Timestamp));
            salelead.Id = lead.Id;
            return CreatedAtRoute("DefaultApi", new { id = salelead.Id }, salelead);
        }

        //[ResponseType(typeof(object))]
        //public IHttpActionResult Get()
        //{

        //    var lead = _serviceSaleLead.RegisterSaleLead(1, 1, 1);
        //    var salesRep = _servicePosition.GetEmployeeInPosition(6);
        //    _serviceSaleLead.AssignSalesEmployee(salesRep.Id, lead.Id);
        //    return Ok();
        //}

        [ResponseType(typeof(SaleLead))]
        [HttpPut]
        public IHttpActionResult Put(SaleLead saleLead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var lead = _serviceSaleLead.UpdateLead(saleLead.Id, saleLead.SaleLeadState.Id, saleLead.SaleId, saleLead.Customer.Id, Convert.ToDateTime(saleLead.Timestamp));
            saleLead.Id = lead.Id;
            return CreatedAtRoute("DefaultApi", new { leadId = saleLead.Id }, saleLead);
        }


        //DELETE: /api/SaleLeads/Destroy
        public IHttpActionResult Delete(SaleLead lead)
        {

            _serviceSaleLead.DeleteLead(lead.Id);
            return Ok();


        }

        [Route("api/saleLeadStates")]
        [HttpGet]
        public IHttpActionResult GetStates()
        {
            var result = _repoSaleLeadState.AsQueryable()
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

            return Ok(result);
        }

        [Route("api/saleLeadCustomers")]
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var result = _repoCustomer.AsQueryable()
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.Name,

                }).ToList();

            return Ok(result);
        }

        #endregion

        #region saleLeadForCustomer

        [HttpGet]
        [Route("api{CustomerId}/SaleLeads")]
        public IHttpActionResult Get([DataSourceRequest] DataSourceRequest request, int CustomerId = 0)
        {
            var list = _serviceSaleLead.ListSaleLeads(CustomerId);
            var slWViewModel = new List<SaleLeadViewModel>();
            foreach (var sl in list)
            {
                var vm = new SaleLeadViewModel { SaleLeadId = sl.Id, StateId = sl.StateId, StateName = sl.SaleLeadState.Name, SaleId = sl.SaleId, Timestamp = Convert.ToDateTime(sl.Timestamp), customerId = sl.CustomerId };
                slWViewModel.Add(vm);
            }
            return Ok(slWViewModel);
        }

        #endregion



        //[ResponseType(typeof(SaleLead))]
        //public IHttpActionResult PostSaleLead(SaleLead saleLead)
        //{
        //    if(!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //   // _serviceSaleLead.RegisterSaleLead(saleLead.StateId, saleLead.CustomerId);
        //    return CreatedAtRoute("DefaultApi", new { id = saleLead.Id }, saleLead);
        //}

        //[ResponseType(typeof(object))]
        //public IHttpActionResult Get()
        //{
        //    var lead = _serviceSaleLead.RegisterSaleLead(1, 1,1);
        //    var salesRep = _servicePosition.GetEmployeeInPosition(6);
        //    _serviceSaleLead.AssignSalesEmployee(salesRep.Id, lead.Id); 
        //    return Ok();
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}
