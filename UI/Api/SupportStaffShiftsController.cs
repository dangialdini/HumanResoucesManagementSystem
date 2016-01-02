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
using Domain.Models;
using Services.Service.Interfaces;
using UI.Areas.Support.Models;
using Services.Repositories.Interfaces;
using Services.Service.Models.Support;

namespace UI.Api
{
    public class SupportStaffShiftsController : ApiController
    {
        private readonly ISupportStaffShiftService _supportStaffShiftService;

        public SupportStaffShiftsController(ISupportStaffShiftService supportStaffShiftService)
        {
            _supportStaffShiftService = supportStaffShiftService;
        }

        [Route("api/SupportStaffShifts/GetEmployees")]
        public IHttpActionResult GetEmployees()
        {
            var employees = _supportStaffShiftService.EmpInSuppPosAsQueryable()
            .Select(e => new
            {
                EmployeeId = e.Id,
                EmployeeName = e.Employee.Firstname + " " + e.Employee.Lastname,
                Title = e.Employee.Firstname + " " + e.Employee.Lastname
            }).ToList();
            return Ok(employees);
        }

        [HttpGet]        
        public IHttpActionResult Get()
        {
            var result = _supportStaffShiftService.AsQueryable()                
                .Select(s => new SupportStaffRosterDTO
                {
                    Id = s.Id,
                    EmployeeId = s.EmployeeInSupportPositionId,
                    Start = s.StartTime,
                    End = s.EndTime,
                    Description = s.Description,
                    Title = s.EmployeeInSupportPosition.Employee.Firstname + " " + s.EmployeeInSupportPosition.Employee.Lastname,
                    Color = s.Color,
                    RecurrenceId = s.RecurrenceId,
                    RecurrenceException = s.RecurrenceException,
                    RecurrenceRule = s.RecurrenceRule
                }).ToList();
            return Ok(result);
        }
  
        [HttpPost]
        public IHttpActionResult Post(SupportStaffRosterDTO model)
        {
            var shift = _supportStaffShiftService.Insert(model.Start, model.End, model.Description, model.EmployeeId, model.Color, model.Title, model.RecurrenceId, model.RecurrenceException, model.RecurrenceRule);
            model.Id = shift.Id;
            model.Title = shift.EmployeeInSupportPosition.Employee.Firstname + " " + shift.EmployeeInSupportPosition.Employee.Lastname;
            return CreatedAtRoute("DefaultApi", new { id = model.Id }, model);
        }

        [HttpPut]        
        public IHttpActionResult Put(SupportStaffRosterDTO model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _supportStaffShiftService.Update(model.Id, model.Start, model.End, model.Description, model.EmployeeId, model.Color, model.Title, model.RecurrenceId, model.RecurrenceException, model.RecurrenceRule);
            return CreatedAtRoute("DefaultApi", model.Id, model);
        }

        [HttpDelete]
        public IHttpActionResult Delete(SupportStaffRosterDTO model)
        {
            _supportStaffShiftService.Delete(model.Id);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
