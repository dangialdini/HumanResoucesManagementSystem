using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Sales
{
    public class ProductViewModel
    {
        private string _name;
        private decimal _price;
        private string _description;

        public int ProductId { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public decimal UnitPrice
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }
    }
}