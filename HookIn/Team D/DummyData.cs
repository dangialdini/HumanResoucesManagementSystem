using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Repositories.Interfaces;
using Services.Repositories;
using SharpRepository.Repository.Specifications;

namespace HookIn.Team_D
{
    class DummyData
    {
        readonly HRMSDBContext db = new HRMSDBContext();

        //CREATE COMPANIES - ADD TO REPO
        public Company CreateNewCompany()
        {
            ICompanyRepository repoCompany = new CompanyRepository(db);

            var company = new Company { ABN = "100100", Name = "Redcat" };
            repoCompany.Add(company);
              
            return company;

        }

        //CREATE PERSONS - ADD TO REPO
        public Person CreateNewPerson()
        {
            IPersonRepository repoPerson = new PersonRepository(db);

            var person = new Person();
            var personOne = new Person { CompanyId = 1, Firstname = "Homer", Lastname = "Simpson", Email = "homer@simpsons.com", Phone = "0412345678" };
            var personTwo = new Person { CompanyId = 1, Firstname = "Marge", Lastname = "Simpson", Email = "marge@simpsons.com", Phone = "0412987654" };
            var personThree = new Person { CompanyId = 1, Firstname = "Peter", Lastname = "Griffin", Email = "peter@griffin.com", Phone = "0498765432" };
            var personFour = new Person { CompanyId = 1, Firstname = "Lois", Lastname = "Griffin", Email = "lois@griffin.com", Phone = "0498123456" };
            var personFive = new Person { CompanyId = 1, Firstname = "Iron", Lastname = "Man", Email = "Iron@man.com", Phone = "0444555666", };
            var personSix = new Person { CompanyId = 1, Firstname = "Black", Lastname = "Widow", Email = "black@widow.com", Phone = "0455666777" };
            repoPerson.Add(personOne);
            repoPerson.Add(personTwo);
            repoPerson.Add(personThree);
            repoPerson.Add(personFour);
            repoPerson.Add(personFive);
            repoPerson.Add(personSix);

            return person;
        }

        //CREATE CUSTOMERS
        public Customer CreateNewCustomer()
        {
            ICustomerRepository repoCustomer = new CustomerRepository(db);

            var customer = new Customer { CompanyId = 1, Name = "Marvel Studios", Email = "marvel@studios.com", Franchise = true, Phone = "0294855649" };
            repoCustomer.Add(customer);

            var customerTwo = new Customer { CompanyId = 1, Name = "Fox Studios", Email = "fox@studios.com", Franchise = true, Phone = "0298347593" };
            repoCustomer.Add(customerTwo);

            return customer;
        }

        //CREATE ADDRESS
        public Address CreateNewAddress()
        {
            IAddressRepository repoAddress = new AddressRepository(db);

            var address = new Address { SuburbId=1, Street1 = "1024 Cherry Street", Street2 = "Langley Falls" };
            var addressTwo = new Address { SuburbId=2, Street1 = "742 Evergreen Terrace", Street2 = "Evergreen Terrace" };
            repoAddress.Add(address);
            repoAddress.Add(addressTwo);

            return addressTwo;
        }

        //CREATE SITE
        public Site CreateNewSite()
        {
            ISiteRepository repoSite = new SiteRepository(db);

            var site = new Site { CustomerId = 2, AddressId = 1, Name = "American Dad", Email = "american@dad.com", HeadQuarters = false, Phone = "0396547891" };            
            var siteTwo = new Site { CustomerId = 2, AddressId = 2, Name = "The Simpsons", Email = "the@simpsons.com", HeadQuarters = false, Phone = "0765481239" };
            repoSite.Add(site);
            repoSite.Add(siteTwo);

            return site;
        }

        //CREATE TICKET STATE
        public TicketState CreateNewTicketState()
        {
            ITicketStateRepository repoTicketState = new TicketStateRepository(db);

            var ticketStateOpen = new TicketState { Name = "Open" };          
            var ticketStateEscalated = new TicketState { Name = "Escalated" };
            var ticketStateClosed = new TicketState { Name = "Closed" };

            repoTicketState.Add(ticketStateOpen);
            repoTicketState.Add(ticketStateEscalated);
            repoTicketState.Add(ticketStateClosed);

            return ticketStateClosed;
        }
    }
}
