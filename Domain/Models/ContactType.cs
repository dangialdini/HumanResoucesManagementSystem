using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class ContactType
    {
        public ContactType()
        {
            this.Contacts = new List<Contact>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
