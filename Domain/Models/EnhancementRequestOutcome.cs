using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class EnhancementRequestOutcome
    {
        public EnhancementRequestOutcome()
        {
            this.EnhancementRequests = new List<EnhancementRequest>();
        }

        public int Id { get; set; }
        public string Result { get; set; }
        public virtual ICollection<EnhancementRequest> EnhancementRequests { get; set; }
    }
}
