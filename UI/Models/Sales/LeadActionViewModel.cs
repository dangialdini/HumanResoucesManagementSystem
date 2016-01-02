using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models.Sales
{
    public class LeadActionViewModel
    {
        private System.DateTime _timestamp;
        private System.DateTime _nextContactDate;
        private string _startTimezone;
        private System.DateTime _endContact;
        private string _endTimezone;
        private string _recurrenceRule;
        private string _recurrenceException;
        private bool _isAllDay;


        public int ActionId { get; set; }
        public int SalePositionLeadId { get; set; }
        public string Title { get; set; }
        public System.DateTime Timestamp
        {
            get
            {
                return _timestamp;
            }
            set
            {
                _timestamp = value;
            }
        }
        public System.DateTime NextContactDate
        {
            get
            {
                return _nextContactDate;
            }
            set
            {
                _nextContactDate = value;
            }
        }
        public string StartTimezone
        {
            get
            {
                return _startTimezone;
            }
            set
            {
                _startTimezone = value;
            }
        }
        public System.DateTime EndContact
        {
            get
            {
                return _endContact;
            }
            set
            {
                _endContact = value;
            }
        }
        public string EndTimezone
        {
            get
            {
                return _endTimezone;
            }
            set
            {
                _endTimezone = value;
            }
        }
        public bool IsAllDay
        {
            get
            {
                return _isAllDay;
            }
            set
            {
                _isAllDay = value;
            }
        }
        public string RecurrenceRule
        {
            get
            {
                return _recurrenceRule;
            }
            set
            {
                _recurrenceRule = value;
            }
        }
        public string RecurrenceException
        {
            get
            {
                return _recurrenceException;
            }
            set
            {
                _recurrenceException = value;
            }
        }
        public SaleCustomerViewModel Customer { get; set; }
        public SaleViewModel Sale { get; set; }
        public SaleEmployeeViewModel Employee { get; set; }
    }
}