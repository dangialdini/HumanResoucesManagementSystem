using Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Services.Repositories.Interfaces;
using Services.Service;
using System;

namespace Tests
{
    [TestClass]
    public class EmployeeServiceTests
    {
        [TestMethod]
        public void UpdateEmployee_ShouldReturnNewEmployee()
        {
            // Fixture set-up 
            var repoEmployeeStub = new EmployeeRepositoryStub(new Employee()
            {
                Id = 1,
                Firstname = "Joe",
                Lastname = "Bloggs",
                Phone = "22222222",
                Email = "joe.bloggs@email.com",
                CompanyId = 2
            });

            var sut = new EmployeeService(repoEmployeeStub, null);

            // Expected result 
            var expected = EmployeeServiceTestUtility.CreateValidEmployee();

            // Exercise the SUT (system under test)
            var actual = sut.updateEmployee(
                employeeId: expected.Id,
                companyId: expected.CompanyId,
                firstName: expected.Firstname,
                lastName: expected.Lastname,
                phone: expected.Phone,
                email: expected.Email);

            // Assertion or verfication phase
            AreEmployeeEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateEmployee_ShouldCallRepositoryUpdate()
        {
            // Fixture set-up
            var repoEmployeeSpy = new EmployeeRepositorySpy(new Employee()
            {
                Id = 1,
                Firstname = "Joe",
                Lastname = "Bloggs",
                Phone = "22222222",
                Email = "joe.bloggs@email.com",
                CompanyId = 2
            });

            var sut = new EmployeeService(repoEmployeeSpy, null);

            // Expected result 
            var expected = EmployeeServiceTestUtility.CreateValidEmployee();

            // Exercise the SUT (system under test), otherwise known as the "Action" phase
            var actual = sut.updateEmployee(
                employeeId: expected.Id,
                companyId: expected.CompanyId,
                firstName: expected.Firstname,
                lastName: expected.Lastname,
                phone: expected.Phone,
                email: expected.Email);

            // Behaviour verification (verifying the SUT interacted correctly with its
            // collaborators/dependencies.  In testing we call dependencies depended on components
            Assert.AreEqual(repoEmployeeSpy.NumTimesGetCalled, 1);
            Assert.AreEqual(repoEmployeeSpy.NumTimesUpdateCalled, 1);
        }

        [TestMethod]
        public void UpdateEmployee_ShouldCallRepositoryUpdateMock()
        {
            // Fixture set-up
            var currentEmployee = new Employee()
            {
                Id = 1,
                Firstname = "Joe",
                Lastname = "Bloggs",
                Phone = "22222222",
                Email = "joe.bloggs@email.com",
                CompanyId = 2
            };

            var repoEmployeeMock = new Mock<IEmployeeRepository>();

            // Using the mock to act as a test stub
            repoEmployeeMock.Setup(r => r.Get(1))
                .Returns(currentEmployee);

            var sut = new EmployeeService(repoEmployeeMock.Object, null);

            // Expected result 
            var expected = EmployeeServiceTestUtility.CreateValidEmployee();

            // Exercise the SUT (system under test), otherwise known as the "Action" phase
            var actual = sut.updateEmployee(
                employeeId: expected.Id,
                companyId: expected.CompanyId,
                firstName: expected.Firstname,
                lastName: expected.Lastname,
                phone: expected.Phone,
                email: expected.Email);

            // Behaviour verification (verifying the SUT interacted correctly with its
            // collaborators/dependencies.  In testing we call dependencies depended on components
            // With Mocks, instead of an Assert we call the verify method on the Mock object

            // Verify that the Get was called with an int matching the current employee, and
            // that it was called exactly once
            repoEmployeeMock.Verify(r => r.Get(expected.Id), Times.Once);

            // Verify that the Update was called with an employee matching the object reference
            // of the currentEmployee object, and that it was called exactly once
            repoEmployeeMock.Verify(r => r.Update(currentEmployee), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException),"Exception that is thrown when employee not found")]
        public void UpdateEmployee_ShouldThrowException()
        {
            // Fixture set-up 
            var repoEmployeeStub = new EmployeeRepositoryStub(null);

            var sut = new EmployeeService(repoEmployeeStub, null);

            var expected = new Employee()
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Smith",
                Phone = "11111111",
                Email = "john.smith@email.com",
                CompanyId = 1
            };


            // Exercise the SUT (system under test)
            var actual = sut.updateEmployee(
                employeeId: expected.Id,
                companyId: expected.CompanyId,
                firstName: expected.Firstname,
                lastName: expected.Lastname,
                phone: expected.Phone,
                email: expected.Email);

            // Assertion or verfication phase
            Assert.IsNull(actual);
        }


        // This is what is called a custom assertion.  In this assertion we are comparing
        // whether two employees are equal
        public static void AreEmployeeEqual(Employee expected, Employee actual)
        {
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Firstname, actual.Firstname);
            Assert.AreEqual(expected.Lastname, actual.Lastname);
            Assert.AreEqual(expected.CompanyId, actual.CompanyId);
        }
    }

    public class EmployeeServiceTestUtility
    {
        public static Employee CreateValidEmployee()
        {
            return new Employee()
            {
                Id = 1,
                Firstname = "John",
                Lastname = "Smith",
                Phone = "11111111",
                Email = "john.smith@email.com",
                CompanyId = 1
            };
        }
    }
}
