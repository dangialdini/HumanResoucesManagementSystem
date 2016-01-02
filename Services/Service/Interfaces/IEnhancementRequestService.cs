using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface IEnhancementRequestService
    {
        EnhancementRequest CreateRequest(int customerId, string description, int weight, int outcomeId, DateTime timestamp);

        int UpdateEnhancementRequestOutcome(int enhancementRequestId, int outcomeId);

        int UpdateEnhancementRequestCustomers(int enhancementRequestId, int customerId);
        EnhancementRequest UpdateRequest(int id, int customerId, string description, int weight, int outcomeId, DateTime timestamp);

        void DeleteRequest(int Id);
        IQueryable<EnhancementRequest> AsQueryable();
    }


}
