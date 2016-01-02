using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UI.Areas.Development.Models;

namespace UI.Api
{
    public class ProjectDevelopmentsController : ApiController
    {
        private IProjectDevelopmentRepository _repoProjectDevelopment;
        private IProjectDevelopmentService _serviceProjectDevelopment;
        private IEmployeeInPositionRepository _repoEmployeeInPosition;

        public ProjectDevelopmentsController(IProjectDevelopmentService serviceProjectDevelopment, IProjectDevelopmentRepository repoProjectDevelopment, IEmployeeInPositionRepository repoEmployeeInPosition)
        {
            _serviceProjectDevelopment = serviceProjectDevelopment;
            _repoProjectDevelopment = repoProjectDevelopment;
            _repoEmployeeInPosition = repoEmployeeInPosition;
        }

        [Route("api/development/employees")]
        public IHttpActionResult GetDevelopmentEmployees()
        {
            var result = _repoEmployeeInPosition.AsQueryable().OfType<EmployeeInDevelopmentPosition>()
                .Select((e) => new
                {
                    Id = e.Id,
                    EmployeeId = e.EmployeeId,
                    FirstName = e.Employee.Firstname,
                    LastName = e.Employee.Lastname
                }).ToList();

            return Ok(result);
        }

        // GET: ProjectDevelopments
        public IHttpActionResult Get()
        {
            var result = _repoProjectDevelopment.GetAll((p) => new ProjectDevelopmentViewModel()
            {
                Id = p.Id,
                EnhancementRequestId = p.EnhancementRequestId,
                EnhancementRequest = p.EnhancementRequest.Description,
                ManagerId = p.ManagerId,
                Start = p.Start,
                Finish = p.Finish,
                EmployeeId = p.EmployeeInDevelopmentPosition.EmployeeId,
                Employee = p.EmployeeInDevelopmentPosition.Employee.Firstname + " " + p.EmployeeInDevelopmentPosition.Employee.Lastname
            }).ToList();

            return Ok(result);
        }

        public IHttpActionResult Get(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var model = _repoProjectDevelopment.Get(id.Value, (p) => new ProjectDevelopmentViewModel()
            {
                Id = p.Id,
                EnhancementRequestId = p.EnhancementRequestId,
                EnhancementRequest = p.EnhancementRequest.Description,
                ManagerId = p.ManagerId,
                Start = p.Start,
                Finish = p.Finish,
                EmployeeId = p.EmployeeInDevelopmentPosition.EmployeeId,
                Employee = p.EmployeeInDevelopmentPosition.Employee.Firstname + " " + p.EmployeeInDevelopmentPosition.Employee.Lastname
            });

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        public IHttpActionResult Post(ProjectDevelopmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var project = _serviceProjectDevelopment.CreateProjectDevelopment(
                    enhancementRequestId: model.EnhancementRequestId,
                    employeeInDevelopmentPositionId: model.ManagerId,
                    description: String.Empty,
                    start: model.Start,
                    finish: model.Finish);

                model.Id = project.Id;

                return Created<ProjectDevelopmentViewModel>(Request.RequestUri + model.Id.ToString(), model);
            }

            return BadRequest(ModelState);
        }

        public IHttpActionResult Put(ProjectDevelopmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var project = _serviceProjectDevelopment.UpdateProjectDevelopment(
                        id: model.Id,
                        enhancementRequestId: model.EnhancementRequestId,
                        employeeInDevelopmentPositionId: model.ManagerId,
                        description: String.Empty,
                        start: model.Start,
                        finish: model.Finish);

                    return Ok(project);
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        public IHttpActionResult Delete(ProjectDevelopmentViewModel model)
        {
            try
            {
                _serviceProjectDevelopment.DeleteProjectDevelopment(model.Id);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}