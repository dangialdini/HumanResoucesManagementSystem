using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Zone
    {
        public Zone()
        {
            this.Suburbs = new List<Suburb>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Suburb> Suburbs { get; set; }
    }
}
