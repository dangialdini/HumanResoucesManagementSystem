using Domain.Models;
using Services.Repositories.Interfaces;
using SharpRepository.EfRepository;
using SharpRepository.Repository.Caching;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Repositories
{
    public class EmployeeInPositionRepository : EfRepository<EmployeeInPosition, int>, IEmployeeInPositionRepository
    {
        public EmployeeInPositionRepository(DbContext dbContext, ICachingStrategy<EmployeeInPosition, int> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
        }

        public EmployeeInPosition RegisterEmployee(Employee e, Position p, bool active = true)
        {
            var existing = e.EmployeeInPositions.FirstOrDefault(eip => eip.PositionId == p.Id);
            if (existing != null)
            {
                return existing;
            }
            var result = p.RegisterEmployee(e, active);
            this.Add(result);
            return result;
        }


        public IQueryable<EmployeeInSupportPosition> GetEmployeesInSupportPosition()
        {
            return base.AsQueryable().OfType<EmployeeInSupportPosition>();
        }

        public IQueryable<EmployeeInSalePosition> GetEmployeeInSalePosition()
        {
            return base.AsQueryable().OfType<EmployeeInSalePosition>();
        }
    }
}
