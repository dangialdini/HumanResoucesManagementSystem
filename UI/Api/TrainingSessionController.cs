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
using UI.Areas.Trainings.Models;

namespace UI.Api
{
    public class TrainingSessionController : ApiController
    {
        private readonly ITrainingSessionService _trainingSessionService;
        private readonly ITrainingService _trainingService;
        public TrainingSessionController(ITrainingSessionService trainingSessionService, ITrainingService trainingService)
        {
            _trainingSessionService = trainingSessionService;
            _trainingService = trainingService;
        }

        [Route("api/employees/training")]
        public IEnumerable<EmployeeListModel> GetEmployees()
        {
            var employees = _trainingSessionService.EmpInTrainPosAsQueryable().Select(e => new EmployeeListModel
            {
                EmployeeId = e.Id,
                EmployeeName = e.Employee.Lastname + ", " + e.Employee.Firstname
            });
            return employees;
        }
        
        [HttpGet]
        [Route("api/TrainingSession")]
        public IHttpActionResult Get()
        {
            var result = _trainingSessionService.TrainingSessionAsQueryable().Select(t => new TrainingSessionViewModel
            {
                Id = t.Id,
                SiteId = t.SiteId,
                TrainingId = t.TrainingId,
                EmployeeTrainerId = t.EmployeeTrainerId,
                Start = t.Start,
                End = DbFunctions.AddMinutes(t.Start, t.DurationInMinutes).Value,
                DurationInMinutes = t.DurationInMinutes,
                Delivered = t.Delivered,
                Title = t.EmployeeInTrainingPostion.Employee.Firstname+" "+t.EmployeeInTrainingPostion.Employee.Lastname
            }).ToList();
            return Ok(result);
        }

        [HttpPost]
        [Route("api/TrainingSession")]
        public IHttpActionResult Post(TrainingSessionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trainingSession = _trainingSessionService.AddTrainingSession(model.SiteId, model.TrainingId, model.EmployeeTrainerId.Value, model.Start, model.DurationInMinutes, model.Delivered);

            model.Id = trainingSession.Id;
            model.End = trainingSession.Start.AddMinutes(model.DurationInMinutes);
            model.Title = trainingSession.EmployeeInTrainingPostion.Employee.Firstname + " " + trainingSession.EmployeeInTrainingPostion.Employee.Lastname;

            return Created<TrainingSessionViewModel>(Request.RequestUri + trainingSession.Id.ToString(), model);
            
        }

        [HttpPut]
        [Route("api/TrainingSession")]
        public IHttpActionResult Put(TrainingSessionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var trainingSession = _trainingSessionService.UpdateTrainingSession(model.Id, model.SiteId, model.TrainingId, model.EmployeeTrainerId.Value, model.Start, model.DurationInMinutes, model.Delivered);
            model.Id = trainingSession.Id;
            model.End = trainingSession.Start.AddMinutes(model.DurationInMinutes);
            model.Title = trainingSession.EmployeeInTrainingPostion.Employee.Firstname + " " + trainingSession.EmployeeInTrainingPostion.Employee.Lastname;
            return Ok(model);
        }

        [HttpDelete]
        [Route("api/TrainingSession")]
        public IHttpActionResult Delete(TrainingSessionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _trainingSessionService.DeleteTrainingSession(model.Id);
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
