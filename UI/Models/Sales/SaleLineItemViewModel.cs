using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Sales
{
    public class SaleLineItemViewModel
    {
        private int _saleId;
        private int _qty;
        private decimal _amount;


        public int SaleLineItemId { get; set; }
        public ProductViewModel Product { get; set; }

        public int saleId
        {
            get { return _saleId; }
            set
            {
                _saleId = value;
            }
        }

        public int Qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
            }
        }
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
            }
        }

        public decimal Subtotal { get; set; }
        public decimal UnitPrice { get; set; }

    }
}