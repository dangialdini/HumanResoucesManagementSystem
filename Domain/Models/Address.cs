using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Address
    {
        public Address()
        {
            this.Offices = new List<Office>();
            this.Sites = new List<Site>();
        }

        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public int SuburbId { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
        public virtual ICollection<Site> Sites { get; set; }
    }
}
