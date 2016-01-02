using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.Models.Sales;

namespace UI.Api
{
    public class SalesHomesController : ApiController
    {
        private readonly ISaleService _serviceSale;
        public SalesHomesController(ISaleService serviceSale)
        {
            _serviceSale = serviceSale;
        }
        [HttpGet]
        [Route("api/Sales/Home/GrossSaleComp")]
        public IHttpActionResult Get()
        {
            var gsc = _serviceSale.GetGrossSaleComp();
            var list = new List<SalesKPIViewModel>();
            foreach (var g in gsc)
            {
                var vm = new SalesKPIViewModel { Employee = new SaleEmployeeViewModel { EmployeeId = g.Employee.EmployeeId, EmployeeName = g.Employee.EmployeeName }, GrossProfit = g.GrossProfit, TotalSales = g.TotalSales, TotalLeads = g.TotalLeads };
                list.Add(vm);

            }
            return Ok(list);

        }

        [HttpGet]
        [Route("api/Sales/Home/CusSaleComp")]
        public IHttpActionResult GetCustomer()
        {
            var gsc = _serviceSale.GetCusSaleComp();
            var list = new List<SalesKPIViewModel>();
            foreach (var g in gsc)
            {
                var vm = new SalesKPIViewModel { Customer = new SaleCustomerViewModel { CustomerId = g.Customer.CustomerId, CustomerName = g.Customer.CustomerName }, GrossProfit = g.GrossProfit, TotalSales = g.TotalSales, TotalLeads = g.TotalLeads };
                list.Add(vm);

            }
            return Ok(list);

        }

        [HttpGet]
        [Route("api/Sales/Home/GrossByDate")]
        public IHttpActionResult GetByDate()
        {
            var gsc = _serviceSale.GetGrossSaleCompDate();
            var list = new List<SalesKPIViewModel>();
            foreach (var g in gsc)
            {
                var vm = new SalesKPIViewModel {Date = g.Date, Employee = new SaleEmployeeViewModel { EmployeeId = g.Employee.EmployeeId, EmployeeName = g.Employee.EmployeeName }, GrossProfit = g.GrossProfit};
                list.Add(vm);

            }
            return Ok(list);

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
