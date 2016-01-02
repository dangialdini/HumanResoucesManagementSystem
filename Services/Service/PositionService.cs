using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using SharpRepository.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class PositionService : IPositionService
    {
        private readonly IEmployeeInPositionRepository _repoEmployeeInPosition;
        private readonly IEmployeeRepository _repoEmployee;
        private readonly IPositionRepository _repoPosition;


        public PositionService(IEmployeeRepository repoEmployee, IEmployeeInPositionRepository repoEmployeeInPosition, IPositionRepository repoPosition)
        {
            _repoEmployeeInPosition = repoEmployeeInPosition;
            _repoEmployee = repoEmployee;
            _repoPosition = repoPosition;
        }

        public EmployeeInPosition RegisterEmployeeInPosition(int employeeId, int positionId, bool active)
        {
            var eSpec = new Specification<Employee>(e => e.Id == employeeId);
            eSpec.FetchStrategy.Include(e => e.EmployeeInPositions.Select(eip => eip.Position));

            var employee = _repoEmployee.Find(eSpec);
            var position = _repoPosition.Get(positionId);
            return _repoEmployeeInPosition.RegisterEmployee(employee, position, active);            
        }
        

        public IEnumerable<EmployeeInPosition> GetEmployeesInPosition(int id)
        {

            var eipSpec = new Specification<EmployeeInPosition>(eip => eip.PositionId == id);
            eipSpec.FetchStrategy.Include(eip => eip.Position).Include(eip => eip.Employee);

            return _repoEmployeeInPosition.FindAll(eipSpec);  
        }
    
        public IQueryable<EmployeeInPosition> GetAllEmployeeInPosition()
        {
            var result = _repoEmployeeInPosition.AsQueryable();
            return result;
        }


        public IEnumerable<Position> Positions
        {
            get
            {
                return _repoPosition.GetAll().AsEnumerable();
            }
        }


        public EmployeeInPosition Update(int id, int empId, int posId, bool active)
        {
            var eip = _repoEmployeeInPosition.Get(id);
            eip.PositionId = posId;
            eip.Active = active;

            _repoEmployeeInPosition.Update(eip);
            
            return eip;
        }

        //public EmployeeInPosition Update(EmployeeInPosition m)
        //{
        //    var eip = _repoEmployeeInPosition.Get(m.id);
        //    eip.PositionId = m.posId;
        //    eip.Active = m.active;

        //    _repoEmployeeInPosition.Update(eip);
        //    return eip;
        //}

        public void Delete(int empId)
        {
            var eip = _repoEmployeeInPosition.Get(empId);
            _repoEmployeeInPosition.Delete(eip);

            //_repoEmployeeInPosition.DeleteInPositon(empId, posId);
        }

        //public void DeleteInPosition(EmployeeInPosition eip)
        //{
        //    var eipResult = _repoEmployeeInPosition.Get(eip.Id);
        //    _repoEmployeeInPosition.DeleteInPositon(eip, eipResult.Id);
        //}
    }
}
