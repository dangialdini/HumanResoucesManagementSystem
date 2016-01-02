//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System.Data.Entity;
//using Domain.Models;
//using Services.Repositories;
//using Services.Service;
//using System.Collections.Generic;
//using System.Linq;
//using Services.Repositories.Interfaces;

//// From site http://www.williablog.net/williablog/post/2009/12/15/Mock-a-database-repository-using-Moq.aspx

//namespace Tests.Support
//{
//    [TestClass]
//    public class UnitTest1
//    {

//        // Gets or sets the test context which provides
//        // information about and functionality for the current test run.
//        public TestContext TestContext { get; set; }

//        //Our Mock Products Repo for use in testing
//        public readonly ISupportStaffShiftRepository MockShiftRepo;

//        // Constructor
//        public UnitTest1()
//        {
//            IList<SupportStaffShift> shifts = new List<SupportStaffShift>
//            {
//                new SupportStaffShift { Id = 1, Description = "AAA" },
//                new SupportStaffShift { Id = 1, Description = "AAA" },
//                new SupportStaffShift { Id = 1, Description = "AAA" }
//            };

//            // Mock the SSS Repo
//            Mock<ISupportStaffShiftRepository> mockShiftRepo = new Mock<ISupportStaffShiftRepository>();

//            // Return all the shifts
//            mockShiftRepo.Setup(m => m.GetShifts()).Returns(shifts);

//            //Complete the setup of our Mock Repository
//            this.MockShiftRepo = mockShiftRepo.Object;
//        }

//        // Can we return all Shifts
//        [TestMethod]
//        public void GetAllShifts()
//        {
//            // Try finding all products
//            IList<SupportStaffShift> testShifts = this.MockShiftRepo.GetShifts().ToList();

//            Assert.IsNotNull(testShifts); // Test if null
//            Assert.AreEqual(3, testShifts.Count); // Verify the correct number
//        }
//    }
//}
