using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Models;


namespace Services.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repoCustomer;
        private readonly ICompanyRepository _repoCompany;

        public CustomerService(ICustomerRepository repoCustomer, ICompanyRepository repoCompany)
        {
            _repoCustomer = repoCustomer;
            _repoCompany = repoCompany;
        }


        //Register new Customer: - Id is auto generated for us.

        public Customer RegisterCustomer(int companyId, string name, string abn, bool franchise, string phone, string email)
        {
            var customer = new Customer { CompanyId = companyId, Name = name, Abn = abn, Franchise = franchise, Phone = phone, Email = email };
            _repoCustomer.Add(customer);
            return customer;
        }

        //Update Customer Details:

        public Customer UpdateDetails(int id, string name, string abn, bool franchise, string phone, string email)
        {
            var customer = _repoCustomer.Get(id);

            _repoCustomer.Update(customer);

            return customer;
        }


        //Delete Customer: throws exception when customer has dependent records
        public void DeleteCustomer(int id)
        {
            var customer = _repoCustomer.Get(id);


            if (customer.Contacts.Count() > 0 || customer.EnhancementRequests.Count() > 0
                || customer.Sites.Count() > 0)
            {
                throw new InvalidOperationException("A customer that has dependent records cannot be deleted");
            }

            _repoCustomer.Delete(customer);
        }
    }
}
