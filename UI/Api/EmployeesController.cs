using Domain.Models;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using UI.Models;
using System.Data.Entity;

namespace UI.Api
{
    public class EmployeesController : ApiController
    {
        private readonly IEmployeeService _serviceEmployee;
        private readonly ICompanyService _serviceCompany;

        public EmployeesController(IEmployeeService serviceEmployee, ICompanyService serviceCompany)
        {
            _serviceEmployee = serviceEmployee;
            _serviceCompany = serviceCompany;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var result = _serviceEmployee.AsQueryable()
                .OrderBy(x => x.Firstname)
                .Select(e => new EmployeeViewModel
                {
                    EmployeeId = e.Id,
                    Company = new CompanyViewModel() { Id = e.Company.Id, Name = e.Company.Name },
                    Firstname = e.Firstname,
                    Lastname = e.Lastname,
                    DateOfBirth = e.DateOfBirth,
                    Phone = e.Phone,
                    Email = e.Email,
                }).ToList();

            return Ok(result);
        }

        [Route("api/companies")]
        [HttpGet]
        public IHttpActionResult GetCompanies()
        {
            var model = _serviceCompany.AsQueryable()
                        .Select(x => new
                        {
                            Id = x.Id,
                            Name = x.Name
                        }).ToList();

            return Ok(model);
        }

        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeViewModel model)
        {
            var emp = _serviceEmployee.CreateEmployee(model.Company.Id, model.Firstname, model.Lastname,  model.DateOfBirth, model.Phone, model.Email);

            model.EmployeeId = emp.Id;

            return CreatedAtRoute("DefaultApi", new { id = model.EmployeeId }, model);
        }

        [HttpPut]
        public IHttpActionResult UpdateEmployee(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _serviceEmployee.UpdateEmployee(model.EmployeeId, model.Company.Id, model.Firstname, model.Lastname,  model.DateOfBirth, model.Phone, model.Email);

            return Ok(model);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(EmployeeViewModel model)
        {
            try
            {
                _serviceEmployee.DeleteEmployee(model.EmployeeId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}