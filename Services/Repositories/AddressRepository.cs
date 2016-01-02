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
    public class AddressRepository : EfRepository<Address, int>, IAddressRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="cachingStrategy"></param>
        public AddressRepository(DbContext dbContext, ICachingStrategy<Address, int> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {

        }

    }
}
