using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using SharpRepository.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Services.Service
{
    public class EnhancementRequestService : IEnhancementRequestService
    {
        private readonly IEnhancementRequestRepository _repoEnhancementRequest;
        private readonly IEnhancementRequestOutcomeRepository _repoEnhancementRequestOutcome;
        private readonly ICustomerRepository _repoCustomer;



        public EnhancementRequestService(IEnhancementRequestRepository repoEnhancementRequest,
            IEnhancementRequestOutcomeRepository repoEnhancementRequestOutcome,
            ICustomerRepository repoCustomer)
        {
            _repoEnhancementRequest = repoEnhancementRequest;
            _repoEnhancementRequestOutcome = repoEnhancementRequestOutcome;
            _repoCustomer = repoCustomer;
        }



        public EnhancementRequest CreateRequest(int customerId, string description, int weight, int outcomeId, DateTime timestamp)
        {
            var request = new EnhancementRequest
            {
                CustomerId = customerId,
                Description = description,
                Weight = weight,
                OutcomeId = outcomeId,
                Timestamp = timestamp
            };

            _repoEnhancementRequest.Add(request);
            return request;
        }


        public int UpdateEnhancementRequestOutcome(int enhancementRequestId, int outcomeId)
        {
            var request = _repoEnhancementRequest.Get(enhancementRequestId);
            request.OutcomeId = outcomeId;
            _repoEnhancementRequest.Update(request);
            return request.OutcomeId;

        }

        public int UpdateEnhancementRequestCustomers(int enhancementRequestId, int customerId)
        {
            var request = _repoEnhancementRequest.Get(enhancementRequestId);
            request.CustomerId = customerId;
            _repoEnhancementRequest.Update(request);
            return request.CustomerId;

        }

        public EnhancementRequest UpdateRequest(int id, int customerId, string description, int weight, int outcomeId, DateTime timestamp)
        {
            var request = _repoEnhancementRequest.Get(id);

            request.CustomerId = customerId;
            request.Description = description;
            request.Weight = weight;
            request.OutcomeId = outcomeId;
            request.Timestamp = timestamp;


            _repoEnhancementRequest.Update(request);
            return request;
        }
        public void DeleteRequest(int Id)
        {
            var request = _repoEnhancementRequest.Get(Id);
            _repoEnhancementRequest.Delete(Id);

        }

        public IQueryable<EnhancementRequest> AsQueryable()
        {
            return _repoEnhancementRequest.AsQueryable();
        }



    }

}
