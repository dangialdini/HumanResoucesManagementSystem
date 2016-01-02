using Domain.Models;
using Services.Repositories;
using Services.Repositories.Interfaces;
using SharpRepository.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_C
{
    public class PhillipHookIn
    {
        private HRMSDBContext db = new HRMSDBContext();

        public SaleLead CreateSaleLead(int stateId, int customerId, DateTime timeStamp)
        {
            ISaleLeadRepository saleLeadRepo = new SaleLeadRepository(db);
            var saleLead = new SaleLead { StateId = stateId, CustomerId = customerId, Timestamp = timeStamp };
            saleLeadRepo.Add(saleLead);

            return saleLead;
        }

        public SaleLeadState CreateSaleLeadState()
        {
            ISaleLeadStateRepository saleLeadStateRepo = new SaleLeadStateRepository(db);
            var saleLeadState = new SaleLeadState();
            var leadStateOpoen = new SaleLeadState { Id = 1, Name = "Open"};
            var leadStateClose = new SaleLeadState { Id = 2, Name = "Closed" };
            var leadStatePending = new SaleLeadState { Id = 3, Name = "Pending" };
            
            saleLeadStateRepo.Add(leadStateOpoen);
            saleLeadStateRepo.Add(leadStateClose);
            saleLeadStateRepo.Add(leadStatePending);

            return saleLeadState;
        }

        public void specificationMethod()
        {
            ISaleLeadRepository saleLeadRepo = new SaleLeadRepository(db);

            var specification = new Specification<SaleLead>(s => s.Id == 1);
            var company = saleLeadRepo.Find(specification);

        }
    }
}
