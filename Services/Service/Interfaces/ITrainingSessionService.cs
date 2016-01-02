using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface ITrainingSessionService
    {
        TrainingSession AddTrainingSession(int siteId, int trainingId, int employeeId, DateTime start, int duration, bool delivered);
        TrainingSession UpdateTrainingSession(int id, int siteId, int trainingId, int employeeId, DateTime start, int duration, bool delivered);
        TrainingSession DeleteTrainingSession(int id);
        IQueryable<TrainingSession> TrainingSessionAsQueryable();
        IQueryable<EmployeeInTrainingPosition> EmpInTrainPosAsQueryable();

    }
}
