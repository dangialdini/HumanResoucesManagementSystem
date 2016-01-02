using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Areas.Sales.Models
{
    public class SaleLeadViewModel
    {
        public int SaleLeadId { get; set; }
        public int StateId { get; set; }
        public int SaleId { get; set; }
        public string StateName { get; set; }
        public DateTime Timestamp { get; set; }

        private int _customerId;

        public int customerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
            }
        }
    }
}