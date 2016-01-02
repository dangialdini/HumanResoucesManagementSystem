using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Services.Repositories.Interfaces;
using Services.Repositories;
using SharpRepository.Repository.Specifications;
using HookIn.Team_D;
using Services.Service;
using Services.Service.Interfaces;
using System.Data.Entity;


namespace HookIn
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new HRMSDBContext();

            // This is to test eager loading for a sale from a sale lead
            var saleLead = db.SaleLeads.Include(l => l.Sale).FirstOrDefault();

            //var employees = db.Employees.Include(e => e.EmployeeInPostions).Where(e => e.EmployeeInPostions.Any(eip => eip.PositionId == 2)).ToArray();
            //var customers = db.Customers.ToArray();
            //var products = db.Products.ToArray();
            var salesPL = db.SalePositionLeads.ToArray();
            var sales = db.Sales.ToArray();
            var r = new Random();

            foreach(var s in sales)
            {
                if(s.OrderNumber < 0)
                {
                    s.OrderNumber = s.OrderNumber * -1;
                    
                }
                if (s.OrderNumber > 99)
                {
                    s.OrderNumber = r.Next(99);
                }
                db.SaveChanges();
                Console.WriteLine(s.OrderNumber);
            }

            foreach (var s in salesPL)
            {
                var b = r.Next(3);
                if (b == 1)
                {
                    s.FinalisedSale = true;
                    db.SaveChanges();
                    Console.WriteLine(s.FinalisedSale);
                }
            }

            //for (var start = new DateTime(2014, 07, 01); start < DateTime.Now; start = start.AddDays(r.Next(7)))
            //{
            //    var e = employees[r.Next(employees.Length)];
            //    var c = customers[r.Next(customers.Length)];

            //    var sale = new Sale { Date = start, OrderNumber = start.GetHashCode() };
            //    db.Sales.Add(sale);
            //    db.SaveChanges();

            //    var lead = new SaleLead { CustomerId = c.Id, SaleId = sale.Id, Timestamp = start.AddDays(-(r.NextDouble())), StateId = 1 };
            //    db.SaleLeads.Add(lead);
            //    db.SaveChanges();

            //    var employeeAssignedToLead = new SalePositionLead { SaleLeadId = lead.Id, EmployeeInSalePostionId = e.EmployeeInPostions.First(eip => eip.PositionId == 2).Id };
            //    db.SalePositionLeads.Add(employeeAssignedToLead);
            //    db.SaveChanges();

            //    for (int i = 0; i < r.Next(10); i++)
            //    {
            //        var p = products[r.Next(products.Length)];
            //        var item = new SaleLineItem { SaleId = sale.Id, ProductId = p.Id, Qty = r.Next(15), Amount = p.UnitPrice };
            //        db.SaleLineItems.Add(item);
            //    }
            //    db.SaveChanges();
            //    Console.WriteLine(start.ToString());

            //}


            //ICompanyRepository repoCompany = new CompanyRepository(db);

            //var company = new Company { ABN = "312", Name = "XYZ" };
            //repoCompany.Add(company);

            //var specification = new Specification<Company>(c => c.Id == 1);
            //specification.FetchStrategy.Include(c => c.People);
            //var company = repoCompany.Find(specification); 

            //Company c2; 
            //if (repoCompany.TryFind<Company>(specification, c => c, out c2))
            //{

            //}

            ////ref & out example
            //int i; 
            //if (int.TryParse("21", out i))
            //{
            //    Console.WriteLine("It was a valid number, the number was: " + i);
            //}


            //load all of the sitting for the restaurant for the specified date
            //var spec = new Specification<Sitting>(s => s.RestaurantId == restaurantId && s.StartTime >= start && s.StartTime <= end);
            //spec.FetchStrategy.Include(s => s.Reservations).Include(s => s.Restaurant);
            //var sittings = _repoSitting.FindAll(spec);


            //Console.ReadKey(); 



            //TEAM D
            //var repo = new SupportStaffShiftRepository(db);
            //var repoList = repo.AsQueryable().ToList();

            //var emp = new EmployeeInPositionRepository(db);
            //////var emplist = emp.GetEmployeesInSupportPosition();

            //var off = new OfficeRepository(db);
            ////var offlist = off.AsQueryable().ToList();


            //var service = new SupportStaffShiftService(repo,emp,off);
            //var serviceShiftList = service.AsQueryable().ToList();
            //var serviceShiftEmp = service.EmpInSuppPosAsQueryable().ToList();
            //var serviceShiftOff = service.OfficeAsQueryable().ToList();
            //var shifts = service.GetEmployeeShifts();

            Console.WriteLine("Hi");
        }

    }
}
