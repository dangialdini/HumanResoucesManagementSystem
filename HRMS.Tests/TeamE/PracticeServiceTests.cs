using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Domain.Models;
using System.Collections.Generic;

namespace HRMS.Tests.TeamE
{
    [TestClass]
    public class PracticeServiceTests
    {
        [TestMethod]
        public void UpdateCustomer_ShouldUpdateName()
        {
            // Fixture set-up
            var customer = new Customer()
            {
                Id = 1,
                Name = "Harold Baldwin"
            };

            var customerRepositoryStub = new CustomerRepositoryStub();

            var practiceService = new HookIn.Team_E.PracticeService(customerRepositoryStub);

            // Expected outcome
            var expected = new Customer()
            {
                Id = 1,
                Name = "Nicholas Attlee"
            };

            // Exercise the SUT (system under test, in this case a method on our service)
            var result = practiceService.UpdateCustomer(customer.Id, expected.Name);

            // State verification, asserting that the state of the returned object is what we
            // expected
            Assert.AreEqual(expected.Name, result.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateCustomer_ShouldThrowArgEx()
        {
            // Fixture set-up
            var customer = new Customer()
            {
                Id = 1,
                Name = "Harold Baldwin"
            };

            var customerRepositoryStub = new CustomerRepositoryStub();

            var practiceService = new HookIn.Team_E.PracticeService(customerRepositoryStub);

            // Expected outcome
            var expected = new Customer()
            {
                Id = 1,
                Name = null
            };

            // Exercise the SUT (system under test, in this case a method on our service)
            var result = practiceService.UpdateCustomer(customer.Id, expected.Name);

            // State verification, asserting that the state of the returned object is what we
            // expected
            Assert.IsNull(result);
        }
    }

    public class CustomerRepositoryStub : HookIn.Team_E.ICustomerRepository
    {
        public CustomerRepositoryStub()
        {
        }

        public System.Collections.Generic.IEnumerable<Domain.Models.Customer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Models.Customer Get(int id)
        {
            return new Customer()
            {
                Id = 1,
                Name = "Harold Baldwin"
            };
        }

        public void Add(Domain.Models.Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Update(Domain.Models.Customer customer)
        {
            // No-op
        }

        public void Delete(Domain.Models.Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
