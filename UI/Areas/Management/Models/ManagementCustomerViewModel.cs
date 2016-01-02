using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Management.Models
{
    public class ManagementCustomerViewModel
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Abn { get; set; }
        public bool Franchise { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}