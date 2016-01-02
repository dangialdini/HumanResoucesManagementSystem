using Domain.Models;
using Services.Repositories;
using Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E
{
    class TeamE_IM
    {
        HRMSDBContext db = new HRMSDBContext();

        public Customer CreateNewCustomer()
        {
            var customer = new Customer();

            ICustomerRepository customerRepo = new CustomerRepository(db);
            var customer1 = new Customer { CompanyId = 1, Name = "Big mama Pies", Phone = "9876 0912", Email = "bibmamapies@gamil.com" };
            customerRepo.Add(customer1);

            var customer2 = new Customer { CompanyId = 1, Name = "Black Gold Coffee", Phone = "9567 3452", Email = "blackgoldcoffee@gmail.com" };
            customerRepo.Add(customer2);

            return customer;
        }

        //public EnhancementRequestOutcome EnhancementReqquestOutcome()
        //{
            
        //    IEnhancementRequestOutcomeRepository enhancementRequestOutcomeRepo = new EnhancementRequestOutcomeRepository(db);
            
        //}
        public EnhancementRequest CreateNewEnhancementRequest()
        {
            var enhancement = new EnhancementRequest();

            IEnhancementRequestRepository enhancementRepo = new EnhancementRequestRepository(db);
            var enhancementRequest = new EnhancementRequest { CustomerId = 2, Description = "Add email capabilities", Weight = 3, OutcomeId = 2 };
            enhancementRepo.Add(enhancementRequest);
            return enhancementRequest;
        }
    }
}
