using Domain.Models;
using Services.Repositories;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_B
{
    class TuanHookIn
    {
        private readonly HRMSDBContext db = new HRMSDBContext();
        public Training CreateTraining(int trainingTypeId, int ratePerHour  )
        {
            ITrainingRepository trainingRepo = new TrainingRepository(db);
            var training = new Training { TrainingTypeId = trainingTypeId, RatePerHour = ratePerHour };
            trainingRepo.Add(training);
            return training;
        }
        public TrainingType CreateTrainingType()
        {
            ITrainingTypeRepository trainingTypeRepo = new TrainingTypeRepository(db);
            var trainingType = new TrainingType();
            var TypeOne = new TrainingType {Id=1,Name=" ",Description=" ",DurationInMinutes= 12};
            var TypeTwo = new TrainingType { Id = 2, Name = " ", Description = " ", DurationInMinutes = 13};
            var TypeThree = new TrainingType { Id = 3, Name = " ", Description = " ", DurationInMinutes =21 };

            trainingTypeRepo.Add(TypeOne);
            trainingTypeRepo.Add(TypeTwo);
            trainingTypeRepo.Add(TypeThree);

            return trainingType;
        }
        //public TrainingSession CreateTrainingSession()
        //{

        //}
    }
}
