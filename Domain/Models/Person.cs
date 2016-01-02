using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Person
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual Company Company { get; set; }
        public virtual Contact Contact { get; set; }

    }
}
