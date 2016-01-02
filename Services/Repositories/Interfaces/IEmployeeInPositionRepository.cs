using Domain.Models;
using SharpRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories.Interfaces
{
    public interface IEmployeeInPositionRepository : IRepository<EmployeeInPosition, int>
    {        
        EmployeeInPosition RegisterEmployee(Employee e, Position p, bool active = true);

        IQueryable<EmployeeInSupportPosition> GetEmployeesInSupportPosition();
        IQueryable<EmployeeInSalePosition> GetEmployeeInSalePosition();
    }
}
