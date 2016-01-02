using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Sales
{
    public class SaleViewModel
    {
        private DateTime _date;
        private int _orderNo;

        public int SaleId { get; set; }
        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
            }
        }
        public int OrderNumber
        {
            get { return _orderNo; }
            set
            {
                _orderNo = value;
            }
        }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public SaleCustomerViewModel Customer { get; set; }
        public SaleEmployeeViewModel Employee { get; set; }
        public bool Finalised { get; set; }
    }

    public class SaleCustomerViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
    }

    public class SaleEmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }

}