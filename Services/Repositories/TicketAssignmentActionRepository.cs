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
   
    public class TicketAssignmentActionRepository :  EfRepository<TicketAssignmentAction, int>, ITicketAssignmentActionRepository
    {
        public TicketAssignmentActionRepository(DbContext dbContext, ICachingStrategy<TicketAssignmentAction, int> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {

        }
        
    }
}
