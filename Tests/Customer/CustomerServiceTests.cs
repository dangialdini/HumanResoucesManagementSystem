using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Repositories.Interfaces;
using SharpRepository.InMemoryRepository;
using Domain.Models;
using Services.Service;

namespace Tests
{
    // This kind of test double is what we call a fake.  It provides a implementation that is close
    // to what the actual class provides
    public class InMemoryCustomerRepository : InMemoryRepository<Customer, int>, ICustomerRepository
    {

    }

    public class InMemoryCompanyRepository : InMemoryRepository<Company, int>, ICompanyRepository
    {

    }

    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void RegisterCustomer_ShouldReturnNewCustomer()
        {
            // Fixture set-up
            ICustomerRepository customerRepo = new InMemoryCustomerRepository();
            ICompanyRepository companyRepo = new InMemoryCompanyRepository();

            CustomerService customerService = new CustomerService(customerRepo, companyRepo);

            Customer expected = new Customer
            {
                Id = 1,
                Email = "customerX@email.com",
                Franchise = true,
                Name = "Customer X",
                Phone = "1234 5678",
                CompanyId = 1
            };

            // Exercise the SUT (system under test)
            Customer actual = customerService.RegisterCustomer(
                companyId: expected.CompanyId,
                name: expected.Name,
                franchise: expected.Franchise,
                phone: expected.Phone,
                email: expected.Email);

            // State verification
            AreCustomerEqual(expected, actual);

            var addedCustomer = customerRepo.Get(expected.Id);
            AreCustomerEqual(expected, addedCustomer);
        }

        public static void AreCustomerEqual(Customer expected, Customer actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Franchise, actual.Franchise);
            Assert.AreEqual(expected.Phone, actual.Phone);
            Assert.AreEqual(expected.Email, actual.Email);
        }
    }
}
