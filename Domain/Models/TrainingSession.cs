using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class TrainingSession
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int TrainingId { get; set; }
        public Nullable<int> EmployeeTrainerId { get; set; }
        public System.DateTime Start { get; set; }
        public int DurationInMinutes { get; set; }
        public bool Delivered { get; set; }
        public virtual EmployeeInTrainingPosition EmployeeInTrainingPostion { get; set; }
        public virtual Site Site { get; set; }
        public virtual Training Training { get; set; }
    }
}
