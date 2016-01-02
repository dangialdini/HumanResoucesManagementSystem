using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface ITrainingService
    {








        TrainingType AddTrainingType(string name, string description, int duration); 
    
        TrainingType UpdateTrainingType(int id, string name, string description, int duration);

        void DeleteTrainingType(int id);


        Training Create(int trainingtypeId, decimal rateperhour);

        Training Update(int id, int trainingtypeId, decimal rateperhour);

        void Delete(int id);


        IQueryable<Training> TrainingAsQueryable();
        IQueryable<TrainingType> TrainingTypeAsQueryable();
        
        
    }
}
