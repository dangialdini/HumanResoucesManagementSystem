using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface IEmployeeService
    {
        Employee CreateEmployee(int companyId, string firstName, string lastName,  DateTime dob, string phone, string email);
        Employee UpdateEmployee(int employeeId, int companyId, string firstName, string lastName,  DateTime dob, string phone, string email);
        void DeleteEmployee(int employeeId);

        IQueryable<Employee> AsQueryable();
    }
}
