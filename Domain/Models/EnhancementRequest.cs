using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EnhancementRequest
    {
        public EnhancementRequest()
        {
            this.Project_Development = new List<Project_Development>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public int Weight { get; set; }
        public int OutcomeId { get; set; }

        public Nullable<System.DateTime> Timestamp { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual EnhancementRequestOutcome EnhanceRequestOutcome { get; set; }
        public virtual ICollection<Project_Development> Project_Development { get; set; }
    }
}
