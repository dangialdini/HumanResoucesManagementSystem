using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E
{
    public class PracticeService
    {
        //private ICustomerRepository _customerRepository;

        //public PracticeService(ICustomerRepository customerRepository)
        //{
        //    _customerRepository = customerRepository;
        //}

        //"Harold -This code is not working atm, will fix later"
    //    public void AddNewSite();
    //    {
    //        var db = new HRMSDBContext();

    //        ISiteRepository repoSite = new SiteRepository(db);
    //        var specification = new Specification<Site>(s => s.Id == 1);
    //        specification.FetchStrategy.Include(s => s.Name)
    //            .Include(s=> s.Phone)
    //            .Include(s=> s.Email)
    //            .Include(s=> s.Franchise)
    //            .Include(s=> s.HeadQuarters)
    //            .Include(s=> s.Customers)
    //            .Include(s=> s.SupportTickets);
    //        var customer = repoCustomer.Find(specification);

    //        Site C2;
    //        if (repoSite.TryFind<Site>(specification, s => s, out C2))
    //        { 

    //        }

        //public Domain.Models.Customer UpdateCustomer(int customerId, string name)
        //{
        //    // Fetch the customer using the repository
        //    var customer = new Customer(_customerRepository.Get(customerId));

        //    // Do some data manipulation
        //    customer.Name = name;

        //    // Ask the repository to update our customer
        //    _customerRepository.Update(customer.Entity);
        //    return customer.Entity;
        //}
    }

    public class Customer
    {
        internal Domain.Models.Customer Entity { get; private set; }

        internal Customer(Domain.Models.Customer entity)
        {
            Entity = entity;
        }

        public string Name
        {
            get
            {
                return Entity.Name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }

                Entity.Name = value;
            }
        }

        public void AddContact(int contactTypeId, string firstName, string lastName)
        {
            Entity.Contacts.Add(new Contact()
            {
                ContactTypeId = contactTypeId
            });
        }
    }
}
