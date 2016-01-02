using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using Services.Service.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using UI.Models.Sales;

namespace UI.Api
{
    public class SalesController : ApiController
    {
        private readonly ISaleService _serviceSale;
        private readonly ISaleRepository _repoSale;
        public SalesController(ISaleService serviceSale, ISaleRepository repoSale)
        {
            _serviceSale = serviceSale;
            _repoSale = repoSale;
        }

        [Route("api/Sales/Stats")]
        [HttpGet]
        public IHttpActionResult GetStats()
        {
            var sales = _serviceSale.ListSales(0);
            var vmList = new List<SalesKPIViewModel>();
            foreach(var s in sales)
            {
                var vm = new SalesKPIViewModel { Date = s.Date, Employee = new SaleEmployeeViewModel { EmployeeId = s.EmployeeId, EmployeeName = s.EmployeeName } };
                vmList.Add(vm);
            }
            return Ok(vmList);
        }

        [Route("api/Sales/SaleCustomers")]
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var list = _serviceSale.GetAllCustomers();
            var vms = new List<SaleCustomerViewModel>();
            foreach (var c in list)
            {
                var vm = new SaleCustomerViewModel { CustomerId = c.Id, CustomerName = c.Name };
                vms.Add(vm);
            }
            return Ok(vms);
        }

        [Route("api/Sales/SaleEmployees")]
        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            var list = _serviceSale.GetAllEmployees();
            var vms = new List<SaleEmployeeViewModel>();
            foreach (var e in list)
            {
                var vm = new SaleEmployeeViewModel { EmployeeId = e.Employee.Id, EmployeeName = e.Employee.Lastname + ", " + e.Employee.Firstname };
                vms.Add(vm);
            }
            return Ok(vms);
        }

        [Route("api/Sales/{CustomerId}")]
        [HttpGet]
        public IHttpActionResult Get(int CustomerId = 0)
        {
            var sales = _serviceSale.ListSales(CustomerId);
            var salesWViewModels = new List<SaleViewModel>();
            foreach (var s in sales)
            {
                var vm = new SaleViewModel { SaleId = s.SaleId, Date = s.Date, OrderNumber = s.OrderNumber, Customer = new SaleCustomerViewModel { CustomerId = s.CustomerId, CustomerName = s.CustomerName }, Employee = new SaleEmployeeViewModel { EmployeeId = s.EmployeeId, EmployeeName = s.EmployeeName }, Finalised = s.Finalised };
                salesWViewModels.Add(vm);
            }
            return Ok(salesWViewModels);
        }

        [HttpGet]
        public IHttpActionResult Get([ModelBinder(typeof(Kendo.Mvc.UI.WebApiDataSourceRequestModelBinder))] DataSourceRequest request)
        {
            //var sales = _serviceSale.ListSales(0);
            //var salesWViewModels = new List<SaleViewModel>();
            //foreach (var s in sales)
            //{
            //    var vm = new SaleViewModel { SaleId = s.SaleId, Date = s.Date, OrderNumber = s.OrderNumber, Customer = new SaleCustomerViewModel { CustomerId = s.CustomerId, CustomerName = s.CustomerName }, Employee = new SaleEmployeeViewModel { EmployeeId = s.EmployeeId, EmployeeName = s.EmployeeName }, Finalised = s.Finalised };
            //    salesWViewModels.Add(vm);
            //}

            var salesWViewModels = _repoSale.AsQueryable().ToDataSourceResult(request,
                s => new SaleViewModel
                {
                    SaleId =
                        s.Id,
                    Date = s.Date,
                    OrderNumber = s.OrderNumber,
                    Customer = new SaleCustomerViewModel
                    {
                        CustomerId = s.SaleLeads.First().CustomerId,
                        CustomerName = s.SaleLeads.First().Customer.Name
                    },
                    Employee = new SaleEmployeeViewModel
                    {
                        EmployeeId = s.SaleLeads.First().SalePositionLeads.Last().EmployeeInSalePosition.EmployeeId,
                        EmployeeName = s.SaleLeads.First().SalePositionLeads.Last().EmployeeInSalePosition.Employee.Lastname + ", " +
                            s.SaleLeads.First().SalePositionLeads.Last().EmployeeInSalePosition.Employee.Firstname
                    },
                    Finalised = s.SaleLeads.First().SalePositionLeads.Last().FinalisedSale
                });

            return Ok(salesWViewModels);
        }
        [HttpPost]
        public IHttpActionResult Post(SaleViewModel model)
        {
            var sale = _serviceSale.RegisterSale(model.Date, model.OrderNumber, new CustomerDTO { CustomerId = model.CustomerId}, model.Finalised, model.EmployeeId);
            var vm = new SaleViewModel { SaleId = sale.SaleId, Date = sale.Date, OrderNumber = sale.OrderNumber, Customer = new SaleCustomerViewModel { CustomerId = sale.CustomerId, CustomerName = sale.CustomerName }, Employee = new SaleEmployeeViewModel { EmployeeId = sale.EmployeeId, EmployeeName = sale.EmployeeName }, Finalised = sale.Finalised };
            return Ok(vm);
        }
        [HttpPut]
        public IHttpActionResult Put(SaleViewModel model)
        {
            var sale = _serviceSale.UpdateSale(model.SaleId, model.Date, model.OrderNumber, new CustomerDTO { CustomerId = model.Customer.CustomerId, CustomerName = model.Customer.CustomerName }, model.Finalised, model.Employee.EmployeeId);
            var vm = new SaleViewModel { SaleId = sale.SaleId, Date = sale.Date, OrderNumber = sale.OrderNumber, Customer = new SaleCustomerViewModel { CustomerId = sale.CustomerId, CustomerName = sale.CustomerName }, Employee = new SaleEmployeeViewModel { EmployeeId = sale.EmployeeId, EmployeeName = sale.EmployeeName }, Finalised = sale.Finalised };
            return Ok(vm);
        }
        public IHttpActionResult Delete(SaleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                BadRequest();
            }
            else
            {
                _serviceSale.DeleteSale(model.SaleId);
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