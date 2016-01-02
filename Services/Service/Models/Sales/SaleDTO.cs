using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Models.Sales
{
    public class SaleDTO
    {
        private DateTime _date;
        private int _orderNo;
        private string _customerName;

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
        public string CustomerName
        {
            get { return _customerName; }
            set
            {
                _customerName = value;
            }
        }
        public int LeadId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool Finalised { get; set; }
    }
}
