using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Management.Models
{
    public class ManagementAddressViewModel
    {
        public int Id { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public int SuburbId { get; set; }
        public string SuburbName { get; set; }
        //public int Postcode { get; set; }
        //public int Latitude { get; set; }
        //public int Longitude { get; set; }
        //public int StateId { get; set; }
        //public string StateName { get; set; }
        //public int CountryId { get; set; }
        //public int CountryName { get; set; }
    }
}