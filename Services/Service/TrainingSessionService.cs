using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using SharpRepository.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class TrainingSessionService : ITrainingSessionService
    {
        private readonly ITrainingSessionRepository _repoTrainingSession;
        private readonly IEmployeeInPositionRepository _repoEmployeeInTrainingPos;

        public TrainingSessionService(ITrainingSessionRepository repotrainingSession, IEmployeeInPositionRepository repoEmployeeInTrainingPos)
        {
            _repoTrainingSession = repotrainingSession;
            _repoEmployeeInTrainingPos = repoEmployeeInTrainingPos;

        }

        public IQueryable<EmployeeInTrainingPosition> EmpInTrainPosAsQueryable()
        {
            return _repoEmployeeInTrainingPos.AsQueryable().OfType<EmployeeInTrainingPosition>();
        }

        public TrainingSession AddTrainingSession(int siteId, int trainingId, int employeeId, DateTime start, int duration, bool delivered)
        {
            // Because we want to have access to the employee in position property on our training session, we need some way to load this from the database.
            // One way would be using lazy loading, so that when we request this property it is loaded from the database.  However, lazy loading is not enabled.
            // So, what we need to do is make use of the EF Context caching.  When we load something from the database, context stores this in a cache.  It is then
            // loaded for any entity that references this loaded data.  In this case, our training session references the EmployeeInPosition that we are loading below
            // As a result, when we save the training session to the database, context will set the EmployeeInPosition property of the training session for us, using
            // the cache
            ISpecification<EmployeeInPosition> specification = new Specification<EmployeeInPosition>(e => e.Id == employeeId);
            specification.FetchStrategy = specification.FetchStrategy.Include(e => e.Employee);
            var employeeInTrainingPosition = _repoEmployeeInTrainingPos.Find(specification);

            var trainingsession = new TrainingSession
            {
                SiteId = siteId,
                TrainingId = trainingId,
                EmployeeTrainerId = employeeId,
                Start = start,
                DurationInMinutes = duration,
                Delivered = delivered
            };
            _repoTrainingSession.Add(trainingsession);
            return trainingsession;
        }
        public TrainingSession UpdateTrainingSession(int id, int siteId, int trainingId, int employeeId, DateTime start, int duration, bool delivered)
        {
            ISpecification<EmployeeInPosition> specification = new Specification<EmployeeInPosition>(e => e.Id == employeeId);
            specification.FetchStrategy = specification.FetchStrategy.Include(e => e.Employee);
            var employeeInTrainingPosition = _repoEmployeeInTrainingPos.Find(specification);

            var trainingsession = _repoTrainingSession.Get(id);
            //var site = _repoSite.Get(siteId);
            //var training = _repoTraining.Get(trainingId);
            //var employeeTrainer = _repoEmployeeInPosition.Get(employeeTrainerId);
            //trainingSession.EmployeeInTrainingPostion = (employeeTrainer as EmployeeInTrainingPosition);
            trainingsession.SiteId = siteId;
            trainingsession.TrainingId = trainingId;
            trainingsession.EmployeeTrainerId = employeeId;
            trainingsession.Start = start;
            trainingsession.DurationInMinutes = duration;
            trainingsession.Delivered = delivered;
            _repoTrainingSession.Update(trainingsession);
            return trainingsession;
        }
        public TrainingSession DeleteTrainingSession(int id)
        {
            var trainingsession = _repoTrainingSession.Get(id);
            _repoTrainingSession.Delete(trainingsession);
            return trainingsession;
        }
        public IQueryable<TrainingSession> TrainingSessionAsQueryable()
        {
            return _repoTrainingSession.AsQueryable();
        }
    }
}

