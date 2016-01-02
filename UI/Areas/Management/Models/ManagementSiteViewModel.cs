using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Management.Models
{
    public class ManagementSiteViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int AddressId { get; set; }
        public string AddressName { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Franchise { get; set; }
        public bool HeadQuarters { get; set; }
    }
}