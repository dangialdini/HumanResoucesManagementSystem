using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Country
    {
        public Country()
        {
            this.States = new List<State>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<State> States { get; set; }
    }
}
