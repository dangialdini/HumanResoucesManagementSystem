using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Contact 
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ContactTypeId { get; set; }
        public virtual ContactType ContactType { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Person Person { get; set; }
    }
}
