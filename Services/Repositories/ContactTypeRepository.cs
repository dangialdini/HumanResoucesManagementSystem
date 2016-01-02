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
    public class ContactTypeRepository : EfRepository<ContactType, int>, IContactTypeRepository
    {
        public ContactTypeRepository(DbContext dbContext, ICachingStrategy<ContactType, int> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {

        }
    }
}
