using Services.Service.Interfaces;
using Services.Service.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.Models.Sales;

namespace UI.Api
{
    public class LeadActionsController : ApiController
    {
        private readonly ISaleLeadService _serviceSaleLead;
        public LeadActionsController(ISaleLeadService serviceSaleLead)
        {
            _serviceSaleLead = serviceSaleLead;
        }
        [HttpGet]
        public IHttpActionResult Get()
        {
            var actions = _serviceSaleLead.ListLeadActions();
            var vmList = new List<LeadActionViewModel>();
            foreach (var a in actions)
            {
                var vm = new LeadActionViewModel { ActionId = a.ActionId, Employee = new SaleEmployeeViewModel { EmployeeId = a.Employee.EmployeeId, EmployeeName = a.Employee.EmployeeName }, Customer = new SaleCustomerViewModel { CustomerId = a.CustomerId, CustomerName = a.CustomerName }, Sale = new SaleViewModel { SaleId = a.Sale.SaleId, OrderNumber = a.Sale.OrderNumber }, EndContact = a.EndContact, NextContactDate = a.NextContactDate, SalePositionLeadId = a.SalePositionLeadId, Timestamp = a.Timestamp, Title = a.Title };
                vmList.Add(vm);
            }
            return Ok(vmList);
        }
        [HttpPost]
        public IHttpActionResult Post(LeadActionViewModel model)
        {
            var a = _serviceSaleLead.RegisterLeadAction(model.NextContactDate, model.Title, model.EndContact, new CustomerDTO { CustomerId = model.Customer.CustomerId, CustomerName = model.Customer.CustomerName }, new SaleDTO { SaleId = model.Sale.SaleId, OrderNumber = model.Sale.OrderNumber }, new EmployeeDTO { EmployeeId = model.Employee.EmployeeId, EmployeeName = model.Employee.EmployeeName});
            var vm = new LeadActionViewModel { ActionId = a.ActionId, Title = a.Title, Employee = new SaleEmployeeViewModel{ EmployeeId = a.Employee.EmployeeId, EmployeeName = a.Employee.EmployeeName}, Customer = new SaleCustomerViewModel { CustomerId = a.CustomerId, CustomerName = a.CustomerName }, Sale = new SaleViewModel { SaleId = a.Sale.SaleId, OrderNumber = a.Sale.OrderNumber }, EndContact = a.EndContact, NextContactDate = a.NextContactDate, Timestamp = a.Timestamp };
            return Ok(vm);
        }
        [HttpPut]
        public IHttpActionResult Put(LeadActionViewModel model)
        {
            var leadAction = _serviceSaleLead.UpdateLeadAction(model.ActionId, model.Title, model.NextContactDate, model.EndContact, model.SalePositionLeadId);
            var vm = new LeadActionViewModel { ActionId = leadAction.ActionId, Title = leadAction.Title, SalePositionLeadId = leadAction.SalePositionLeadId, Employee = new SaleEmployeeViewModel { EmployeeId = leadAction.Employee.EmployeeId, EmployeeName = leadAction.Employee.EmployeeName }, Customer = new SaleCustomerViewModel { CustomerId = leadAction.CustomerId, CustomerName = leadAction.CustomerName }, Sale = new SaleViewModel { SaleId = leadAction.Sale.SaleId, OrderNumber = leadAction.Sale.OrderNumber }, EndContact = leadAction.EndContact, NextContactDate = leadAction.NextContactDate, Timestamp = leadAction.Timestamp };
            return Ok(vm);
        }
        public IHttpActionResult Delete(LeadActionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            else
            {
                _serviceSaleLead.RemoveLeadAction(model.ActionId);
                return Ok();
            }
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
