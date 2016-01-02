using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Suburb
    {
        public Suburb()
        {
            this.Addresses = new List<Address>();
        }

        public int Id { get; set; }
        public int StateId { get; set; }
        public string Postcode { get; set; }
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int ZoneId { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual State State { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
