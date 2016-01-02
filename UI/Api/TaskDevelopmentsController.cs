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
    public class TaskDevelopmentsController : ApiController
    {
        private ITaskDevelopmentRepository _repoTaskDevelopment;
        private IProjectDevelopmentService _serviceProjectDevelopment;
        private IEmployeeInPositionRepository _repoEmployeeInPosition;

        public TaskDevelopmentsController(IProjectDevelopmentService serviceProjectDevelopment, ITaskDevelopmentRepository repoTaskDevelopment, IEmployeeInPositionRepository repoEmployeeInPosition)
        {
            _serviceProjectDevelopment = serviceProjectDevelopment;
            _repoTaskDevelopment = repoTaskDevelopment;
            _repoEmployeeInPosition = repoEmployeeInPosition;
        }

        [HttpGet]
        public IHttpActionResult Get(int? projectId)
        {
            if (projectId == null)
            {
                return BadRequest();
            }

            var result = _repoTaskDevelopment.Find(
                t => t.ProjectId == projectId.Value,
                t => new TaskDevelopmentViewModel()
                {
                    Id = t.Id,
                    ProjectId = t.ProjectId,
                    Description = t.Description,
                    DeveloperId = t.DeveloperId,
                    Start = t.Start,
                    Finish = t.Finish
                });

            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post(TaskDevelopmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var task = _serviceProjectDevelopment.CreateTaskDevelopment(
                    projectDevelopmentId: model.ProjectId,
                    employeeInDevelopmentPositionId: model.DeveloperId,
                    description: model.Description,
                    start: model.Start,
                    finish: model.Finish);

                model.Id = task.Id;

                return Created<TaskDevelopmentViewModel>(Request.RequestUri + model.Id.ToString(), model);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete]
        public IHttpActionResult Delete(TaskDevelopmentViewModel model)
        {
            try
            {
                _serviceProjectDevelopment.DeleteTaskDevelopment(
                projectDevelopmentId: model.ProjectId,
                taskDevelopmentId: model.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
