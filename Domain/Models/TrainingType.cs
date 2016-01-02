using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class TrainingType
    {
        public TrainingType()
        {
            this.Trainings = new List<Training>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DurationInMinutes { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
    }
}
