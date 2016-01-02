using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface IPositionService
    {
        EmployeeInPosition RegisterEmployeeInPosition(int employeeId, int positionId, bool active = true);
        IEnumerable<EmployeeInPosition> GetEmployeesInPosition(int id);
        IQueryable<EmployeeInPosition> GetAllEmployeeInPosition();
        IEnumerable<Position> Positions { get; }       
        EmployeeInPosition Update(int id, int empId, int posId, bool active);
        //EmployeeInPosition Update(EmployeeInPosition m);
        void Delete(int empId);        
    }
}
