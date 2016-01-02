using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ProjectDevelopmentService : IProjectDevelopmentService
    {
        private readonly IProjectDevelopmentRepository _repoProjectDevelopment;
        private readonly ITaskDevelopmentRepository _repoTaskDevelopment;

        public ProjectDevelopmentService(IProjectDevelopmentRepository repoProjectDevelopment, ITaskDevelopmentRepository repoTaskDevelopment)
        {
            _repoProjectDevelopment = repoProjectDevelopment;
            _repoTaskDevelopment = repoTaskDevelopment;
        }


        public Project_Development CreateProjectDevelopment(int enhancementRequestId, int employeeInDevelopmentPositionId, string description, DateTime start, DateTime finish)
        {
            var projectDevelopment = new Project_Development
            {
                EnhancementRequestId = enhancementRequestId,
                ManagerId = employeeInDevelopmentPositionId,
                Start = start,
                Finish = finish
            };
            _repoProjectDevelopment.Add(projectDevelopment);

            return projectDevelopment;
        }

        public Project_Development UpdateProjectDevelopment(int id, int enhancementRequestId, int employeeInDevelopmentPositionId, string description, DateTime start, DateTime finish)
        {
            var projectDevelopment = _repoProjectDevelopment.Get(id);

            if (projectDevelopment == null)
            {
                throw new InvalidOperationException("No project with the provided identity was found");
            }

            projectDevelopment.EnhancementRequestId = enhancementRequestId;
            projectDevelopment.ManagerId = employeeInDevelopmentPositionId;
            projectDevelopment.Start = start;
            projectDevelopment.Finish = finish;

            _repoProjectDevelopment.Update(projectDevelopment);

            return projectDevelopment;
        }

        public void DeleteProjectDevelopment(int id)
        {
            var projectDevelopment = _repoProjectDevelopment.Get(id);

            if (projectDevelopment == null)
            {
                throw new InvalidOperationException("No project with the provided identity was found");
            }

            _repoProjectDevelopment.Delete(projectDevelopment);
        }

        public Task_Development CreateTaskDevelopment(int projectDevelopmentId, int employeeInDevelopmentPositionId,
                                                string description, DateTime start, DateTime finish)
        {
            var taskDevelopment = new Task_Development
            {
                ProjectId = projectDevelopmentId,
                DeveloperId = employeeInDevelopmentPositionId,
                Description = description,
                Start = start,
                Finish = finish
            };
            _repoTaskDevelopment.Add(taskDevelopment);

            return taskDevelopment;
        }

        public void DeleteTaskDevelopment(int projectDevelopmentId, int taskDevelopmentId)
        {
            var spec = new SharpRepository.Repository.Specifications.Specification<Project_Development>(p => p.Id == projectDevelopmentId);
            spec.FetchStrategy.Include(p => p.Task_Development);

            var projectDevelopment = _repoProjectDevelopment.Find(spec);

            if (projectDevelopment == null)
            {
                throw new InvalidOperationException("No project with the provided identity was found");
            }

            var taskDevelopment = projectDevelopment.Task_Development.FirstOrDefault(t => t.Id == taskDevelopmentId);

            if (taskDevelopment == null)
            {
                throw new InvalidOperationException("No task with the provided identity was found");
            }

            _repoTaskDevelopment.Delete(taskDevelopment);
        }
    }
}
