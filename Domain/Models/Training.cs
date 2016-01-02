using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Training
    {
        public Training()
        {
            this.TrainingSessions = new List<TrainingSession>();
        }

        public int Id { get; set; }
        public int TrainingTypeId { get; set; }
        public decimal RatePerHour { get; set; }
        public virtual TrainingType TrainingType { get; set; }
        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
