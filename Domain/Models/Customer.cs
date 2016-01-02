using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Contacts = new List<Contact>();
            this.EnhancementRequests = new List<EnhancementRequest>();
            this.SaleLeads = new List<SaleLead>();
            this.Sites = new List<Site>();
        }

        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Abn { get; set; }
        public bool Franchise { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<EnhancementRequest> EnhancementRequests { get; set; }
        public virtual ICollection<SaleLead> SaleLeads { get; set; }
        public virtual ICollection<Site> Sites { get; set; }
    }
}
