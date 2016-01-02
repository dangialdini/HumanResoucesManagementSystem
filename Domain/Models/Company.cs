using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Company
    {
        public Company()
        {
            this.Customers = new List<Customer>();
            this.People = new List<Person>();
            this.Offices = new List<Office>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ABN { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Office> Offices { get; set; }
    }
}
