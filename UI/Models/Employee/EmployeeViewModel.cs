using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class EmployeeViewModel
    {
        private string _firstName;
        private string _lastName;
        private System.DateTime _dateOfBirth;
        private string _phone;
        private string _email;
        
        public CompanyViewModel Company;
        public GenderViewModel Gender;
        public int EmployeeId { get; set; }

        public string Firstname
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        public System.DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
            }
        }

        public string Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
    }
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class GenderViewModel
    {
        public int Id { get; set; }
        public string GenderType { get; set; }
    }
}