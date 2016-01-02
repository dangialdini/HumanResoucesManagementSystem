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
    public class TrainingService : ITrainingService
    {
        private readonly ITrainingRepository _RepoTraining;
        private readonly ITrainingTypeRepository _repoTrainingType;
        public TrainingService(ITrainingRepository RepoTraining, ITrainingTypeRepository repoTrainingType)
        {
            _RepoTraining = RepoTraining;
            _repoTrainingType = repoTrainingType;
        }
        public TrainingType AddTrainingType(string name, string description, int duration)
        {
            var trainingType = new TrainingType
            {
                Name = name,
                Description = description,
                DurationInMinutes = duration
            };
            _repoTrainingType.Add(trainingType);
            return trainingType;
        }
        public TrainingType UpdateTrainingType(int id, string name, string description, int duration)
        {
            var trainingType = _repoTrainingType.Get(id);
            trainingType.Name = name;
            trainingType.Description = description;
            trainingType.DurationInMinutes = duration;
            _repoTrainingType.Update(trainingType);
            return trainingType;
        }
        public void DeleteTrainingType(int id)
        {
            _repoTrainingType.Delete(_repoTrainingType.Get(id));
        }
        public Training Create(int trainingtypeId, decimal rateperhour)
        {
            var trainingType = _repoTrainingType.Get(trainingtypeId);
            var training = new Training { TrainingTypeId = trainingtypeId, RatePerHour = rateperhour };
            _RepoTraining.Add(training);
            return training;
        }
        public Training Update(int id, int trainingtypeId, decimal rateperhour)
        {
            var trainingType = _repoTrainingType.Get(trainingtypeId);
            var training = _RepoTraining.Get(id);
            training.TrainingTypeId = trainingtypeId;
            training.RatePerHour = rateperhour;
            _RepoTraining.Update(training);
            return training;
        }
        public void Delete(int id)
        {
            _RepoTraining.Delete(_RepoTraining.Get(id));
        }



        public IQueryable<Training> TrainingAsQueryable()
        {
            return _RepoTraining.AsQueryable();
        }

        public IQueryable<TrainingType> TrainingTypeAsQueryable()
        {
            return _repoTrainingType.AsQueryable();
        }
    }
}
