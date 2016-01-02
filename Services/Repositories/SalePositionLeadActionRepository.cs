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
    public class SalePositionLeadActionRepository : EfRepository<SalePositionLeadAction, int>, ISalePositionLeadActionRepository
    {
        public SalePositionLeadActionRepository(DbContext dbContext, ICachingStrategy<SalePositionLeadAction, int> cachingStrategy = null)
            :base (dbContext, cachingStrategy)
        {

        }
    }
}
