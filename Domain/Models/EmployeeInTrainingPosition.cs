using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EmployeeInTrainingPosition : EmployeeInPosition
    {
        public EmployeeInTrainingPosition()
        {
            this.TrainingSessions = new List<TrainingSession>();
        }


        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }



        public override EmployeeInPosition.PositionType Role
        {
            get { return PositionType.Training; }
        }
    }
}
