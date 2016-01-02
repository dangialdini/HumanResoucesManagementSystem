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
    public class SupportTicketAssignmentRepository : EfRepository<SupportTicketAssignment, int>, ISupportTicketAssignmentRepository
    {
        public SupportTicketAssignmentRepository(DbContext dbContext, ICachingStrategy<SupportTicketAssignment, int> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {

        }
    }
}
