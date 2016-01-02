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
    public class OfficeRepository : EfRepository<Office, int>, IOfficeRepository
    {
        private readonly HRMSDBContext _db;
        public OfficeRepository(DbContext dbContext, ICachingStrategy<Office, int> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
            _db = (HRMSDBContext)dbContext;
        }

        public override IQueryable<Office> AsQueryable()
        {
            return base.AsQueryable();
        }
    }
}
