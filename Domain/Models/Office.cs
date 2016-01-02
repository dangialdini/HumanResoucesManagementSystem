using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Office
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual Company Company { get; set; }
    }
}
