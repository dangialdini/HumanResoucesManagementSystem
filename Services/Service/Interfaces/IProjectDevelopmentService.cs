using Domain.Models;
using System;

namespace Services.Service.Interfaces
{
    public interface IProjectDevelopmentService
    {
        Project_Development CreateProjectDevelopment(int enhancementRequestId, int employeeInDevelopmentPositionId,
                                                        string description, DateTime start, DateTime finish);

        Project_Development UpdateProjectDevelopment(int id, int enhancementRequestId, int employeeInDevelopmentPositionId,
                                                        string description, DateTime start, DateTime finish);

        void DeleteProjectDevelopment(int id);

        Task_Development CreateTaskDevelopment(int projectDevelopmentId, int employeeInDevelopmentPositionId,
                                                string description, DateTime start, DateTime finish);

        void DeleteTaskDevelopment(int projectDevelopmentId, int taskDevelopmentId);
    }
}