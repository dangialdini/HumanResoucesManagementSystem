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
    public class SupportStaffShiftRepository : EfRepository<SupportStaffShift, int>, ISupportStaffShiftRepository
    {
        private readonly HRMSDBContext _db;
        public SupportStaffShiftRepository(DbContext dbContext, ICachingStrategy<SupportStaffShift, int> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
            _db = (HRMSDBContext)dbContext;
        }

        public override IQueryable<SupportStaffShift> AsQueryable()
        {
            return base.AsQueryable();
        }

    }
}