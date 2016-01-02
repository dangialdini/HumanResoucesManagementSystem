using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repoEmployee;

        public EmployeeService(IEmployeeRepository repoEmployee)
        {
            _repoEmployee = repoEmployee;
        }

        public Employee CreateEmployee(int companyId, string firstName, string lastName,  DateTime dob, string phone, string email)
        {
            var employee = new Employee
            {
                CompanyId = companyId,
                Firstname = firstName,
                Lastname = lastName,
                DateOfBirth = dob,
                Phone = phone,
                Email = email
            };

            _repoEmployee.Add(employee);

            return employee;
        }

        public Employee UpdateEmployee(int employeeId, int companyId, string firstName, string lastName,  DateTime dob, string phone, string email)
        {
            var employee = _repoEmployee.Get(employeeId);

            employee.CompanyId = companyId;
            employee.Firstname = firstName;
            employee.Lastname = lastName;
            employee.DateOfBirth = dob;
            employee.Phone = phone;
            employee.Email = email;

            _repoEmployee.Update(employee);

            return employee;
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _repoEmployee.Get(employeeId);

            _repoEmployee.Delete(employee);
        }

        public IQueryable<Employee> AsQueryable()
        {
            return _repoEmployee.AsQueryable();
        }
    }
}
