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
    public class EmployeeRepository : EfRepository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext dbContext, ICachingStrategy<Employee, int> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
          
        }


        public override IQueryable<Employee> AsQueryable()
        {
            return base.AsQueryable();
        }
    }
}
