using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using Services.Service.Models.Sales;
using SharpRepository.Repository.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Service
{
    public class SaleService : ISaleService
    {
        private readonly ISaleLeadRepository _repoSaleLead;
        private readonly IEmployeeInPositionRepository _repoEmployeeInPosition;
        private readonly ICustomerRepository _repoCustomer;
        private readonly ISaleRepository _repoSale;
        private readonly ISaleLineItemRepository _repoSaleLineItem;
        private readonly IProductRepository _repoProduct;
        private readonly ISaleLeadStateRepository _repoLeadState;
        private readonly ISalePositionLeadRepository _repoSalePositionLead;
        public SaleService(ISalePositionLeadRepository repoSalePositionLead, ISaleLeadStateRepository repoLeadState, ISaleLeadRepository repoSaleLead, ISaleRepository repoSale, ISaleLineItemRepository repoSaleLineItem, IProductRepository repoProduct, IEmployeeInPositionRepository repoEmployeeInPosition, ICustomerRepository repoCustomer)
        {
            _repoSaleLead = repoSaleLead;
            _repoSale = repoSale;
            _repoSaleLineItem = repoSaleLineItem;
            _repoProduct = repoProduct;
            _repoEmployeeInPosition = repoEmployeeInPosition;
            _repoCustomer = repoCustomer;
            _repoLeadState = repoLeadState;
            _repoSalePositionLead = repoSalePositionLead;
        }

        #region Products
        public IEnumerable<Product> ListProducts()
        {
            var list = _repoProduct.GetAll();
            return list;
        }
        public Product RegisterProduct(string name, decimal price, string description)
        {
            var product = new Product { ProductName = name, UnitPrice = price, Description = description };
            _repoProduct.Add(product);
            return product;
        }

        public Product FetchProduct(int id)
        {
            var product = _repoProduct.Get(id);
            return product;
        }

        public Product UpdateProduct(int id, string name, decimal price, string description)
        {
            var product = FetchProduct(id);
            product.ProductName = name;
            product.UnitPrice = price;
            product.Description = description;
            _repoProduct.Update(product);
            return product;
        }

        public void DeleteProduct(int id)
        {
            _repoProduct.Delete(id);
        }
        #endregion

        //public void GenerateSaleData()
        //{

        //    var employees = GetAllEmployees().ToArray();
        //    var customers = GetAllCustomers();

        //    var empRandom = new Random();
        //    var custRandom = new Random(); 


        //    CryptoRandom rand = new CryptoRandom();


        //    for(var index = new DateTime(2014, 7, 1); index < DateTime.Now; index = index.AddDays(rand.Next(1,7)))
        //    {
        //        CryptoRandom random = new CryptoRandom();
        //        Thread.Sleep(500);

        //        var employeeDailySaleCount = empRandom.Next(1, employees.Length - 1);


        //        for (var n = 0; n <= employeeDailySaleCount; n++)
        //        {
        //            var randomCustomerIndex = custRandom.Next(1, customers.Count() - 1);
        //            var customer = customers.ElementAt(randomCustomerIndex);

        //            var randomEmployeeIndex = empRandom.Next(1, employees.Count() - 1);
        //            var employee = employees[randomEmployeeIndex];

        //            var cusDTO = new CustomerDTO { CustomerId = customer.Id, CustomerName = customer.Name };


        //            var fin = random.Next(1, 3);
        //            var b = false;
        //            if (fin > 1)
        //            {
        //                b = true;
        //            }
        //            var s = RegisterSale(index, random.Next(1, 100), cusDTO, b, employee.Id);

        //            var pList = _repoProduct.AsQueryable().Where(v => v.Id > 0).ToArray();

        //            int numberOfItems = random.Next(1, 10);
        //            for (int i = 0; i < numberOfItems; i++)
        //            {
        //                var qty = random.Next(1, 10);
        //                var pId = random.Next(1, pList.Length - 1);
        //                var product = FetchProduct(pId);
        //                while(product == null)
        //                {
        //                    pId++;
        //                    product = FetchProduct(pId);
        //                }
        //                var sli = RegisterSaleLineItem(pId, s.SaleId, qty);
        //            }

        //        }

        //    }

        //}

        #region Sale


        public List<SaleDTO> ListSales(int CustomerId)
        {
            //GenerateSaleData();
            var list = new List<Sale>();
            if (CustomerId != 0)
            {
                var cusSpec = new Specification<SaleLead>(s => s.CustomerId == CustomerId);
                list = _repoSaleLead.AsQueryable().Where(c => c.CustomerId == CustomerId).Select(s => s.Sale).ToList();
            }
            else
            {
                list = _repoSale.AsQueryable().Select(x => x).ToList();
            }
            var dtoList = new List<SaleDTO>();
            foreach (var lis in list)
            {
                var emp = FindOrCreateSalePositionLead(lis, null);
                var record = ConvertToDTO(lis, emp.FinalisedSale, emp);
                dtoList.Add(record);
            }

            return dtoList;
        }
        public SaleDTO RegisterSale(DateTime date, int orderNo, CustomerDTO cus, Boolean finalised, int EmpId)
        {
            var sale = FindOrCreateSaleLead(cus, orderNo, date, finalised);
            if (sale.Id != 0)
            {
                var saleUpdate = UpdateSale(sale.Id, sale.Date, sale.OrderNumber, cus, finalised, EmpId);
            }
            var emp = FindOrCreateSalePositionLead(sale, cus);
            UpdateSalePositionLead(emp, finalised);
            var saleDTO = ConvertToDTO(sale, finalised, emp, cus);
            return saleDTO;

        }

        public Sale FindOrCreateSaleLead(CustomerDTO cus, int orderNo, DateTime date, Boolean finalised)
        {
            SaleLead lead = null;
            if(cus != null)
            {
                var cusSpec = new Specification<SaleLead>(c => c.CustomerId == cus.CustomerId);
                var saleSpec = new Specification<SaleLead>(s => s.Sale.OrderNumber == orderNo);
                var cusAndSale = cusSpec.And(saleSpec);
                lead = _repoSaleLead.Find(cusAndSale);
            }
            if (lead == null)
            {
                var orderSpec = new Specification<Sale>(x => x.OrderNumber == orderNo);
                var dateSpec = new Specification<Sale>(y => y.Date == date);
                var orderAndDate = orderSpec.And(dateSpec);
                var sale = _repoSale.Find(orderAndDate);
                if(sale == null)
                {
                    sale = new Sale { Date = date, OrderNumber = orderNo };
                    _repoSale.Add(sale);
                }
                var state = _repoLeadState.AsQueryable().FirstOrDefault();
                if(cus != null)
                {
                    var customer = _repoCustomer.Get(cus.CustomerId);
                    var newLead = new SaleLead { SaleId = sale.Id, Sale = sale, SaleLeadState = state, StateId = state.Id, Customer = customer, CustomerId = customer.Id };
                    _repoSaleLead.Add(newLead);
                    return sale;
                }
                else
                {
                    var customer = _repoCustomer.AsQueryable().FirstOrDefault();
                    var newLead = new SaleLead { SaleId = sale.Id, Sale = sale, SaleLeadState = state, StateId = state.Id, Customer = customer, CustomerId = customer.Id };
                    _repoSaleLead.Add(newLead);
                    return sale;
                }
                
            }
            else
            {
                var sale = _repoSale.AsQueryable().FirstOrDefault(s => s.Id == lead.Sale.Id);
                return sale;
            }
        }

        public Sale FetchSale(int id)
        {
            var sale = _repoSale.Get(id);
            return sale;
        }

        public SaleDTO UpdateSale(int id, DateTime date, int orderNo, CustomerDTO cus, Boolean finalised, int EmpId)
        {
            var sale = FetchSale(id);
            sale.Date = date;
            sale.OrderNumber = orderNo;
            _repoSale.Update(sale);
            var emp = FindOrCreateSalePositionLead(sale, cus);
            UpdateSalePositionLead(emp, finalised);
            var record = ConvertToDTO(sale, finalised, emp, cus);
            return record;
        }

        public void DeleteSale(int id)
        {
            _repoSale.Delete(id);
        }

        public SaleDTO ConvertToDTO(Sale sale, Boolean finalised, SalePositionLead emp, CustomerDTO cus = null)
        {
            if (cus == null)
            {
                var leadSpec = new Specification<SaleLead>(l => l.SaleId == sale.Id);
                var cusId = _repoSaleLead.Find(leadSpec);
                if (cusId != null)
                {
                    var cusSpec = new Specification<Customer>(c => c.Id == cusId.CustomerId);
                    var cusName = _repoCustomer.Find(cusSpec).Name;
                    var record = new SaleDTO { SaleId = sale.Id, Date = sale.Date, OrderNumber = sale.OrderNumber, CustomerId = cusId.CustomerId, CustomerName = cusName, EmployeeId = emp.EmployeeInSalePosition.Employee.Id, EmployeeName = emp.EmployeeInSalePosition.Employee.Lastname + ", " + emp.EmployeeInSalePosition.Employee.Firstname, Finalised = finalised };
                    return record;
                }
                else
                {
                    return new SaleDTO { SaleId = sale.Id, Date = sale.Date, OrderNumber = sale.OrderNumber, EmployeeId = emp.EmployeeInSalePosition.Employee.Id, EmployeeName = emp.EmployeeInSalePosition.Employee.Lastname + ", " + emp.EmployeeInSalePosition.Employee.Firstname, Finalised = emp.FinalisedSale };
                }
            }
            else
            {
                return new SaleDTO { SaleId = sale.Id, Date = sale.Date, OrderNumber = sale.OrderNumber, CustomerId = cus.CustomerId, CustomerName = cus.CustomerName, EmployeeId = emp.EmployeeInSalePosition.Employee.Id, EmployeeName = emp.EmployeeInSalePosition.Employee.Lastname + ", " + emp.EmployeeInSalePosition.Employee.Firstname, Finalised = emp.FinalisedSale };
            }


        }

        public SalePositionLead FindOrCreateSalePositionLead(Sale sale, CustomerDTO cus)
        {
            var empSaleSpec = new Specification<SalePositionLead>(s => s.SaleLead.Sale.Id == sale.Id);
            var emp = _repoSalePositionLead.Find(empSaleSpec);
            if (emp == null)
            {
                var sa = FindOrCreateSaleLead(cus, sale.OrderNumber, sale.Date, false);
                var sl = _repoSaleLead.AsQueryable().FirstOrDefault(s => s.Sale.Id == sale.Id);
                var empPos = _repoEmployeeInPosition.GetEmployeeInSalePosition().FirstOrDefault(s => s.Position.Name == "Sales");
                emp = new SalePositionLead { FinalisedSale = false, SaleLead = sl, SaleLeadId = sl.Id, EmployeeInSalePosition = empPos, EmployeeInSalePostionId = empPos.Id };
                _repoSalePositionLead.Add(emp);
            }
            return emp;
        }
        public void UpdateSalePositionLead(SalePositionLead emp, Boolean finalised)
        {
            emp.FinalisedSale = finalised;
            _repoSalePositionLead.Update(emp);
        }

        #endregion

        #region SaleLineItem
        public IEnumerable<SaleLineItem> ListSaleLineItems(int saleId)
        {
            var spec = new Specification<SaleLineItem>(s => s.SaleId == saleId);
            var list = _repoSaleLineItem.FindAll(spec);
            return list;
        }

        public SaleLineItem RegisterSaleLineItem(int productId, int saleId, int qty, decimal amount)
        {
            var product = FetchProduct(productId);
            var sale = FetchSale(saleId);
            var sli = new SaleLineItem { ProductId = productId, Product = product, SaleId = saleId, Sale = sale, Qty = qty, Amount = amount };
            _repoSaleLineItem.Add(sli);
            return sli;
        }

        public SaleLineItem FetchSaleLineItem(int id)
        {
            var sli = _repoSaleLineItem.Get(id);
            return sli;
        }

        public SaleLineItem UpdateSaleLineItem(int id, int productId, int saleId, int qty, decimal amount)
        {
            var product = FetchProduct(productId);
            var sale = FetchSale(saleId);
            var sli = FetchSaleLineItem(id);
            sli.ProductId = productId;
            sli.Product = product;
            sli.SaleId = saleId;
            sli.Sale = sale;
            sli.Qty = qty;
            sli.Amount = amount;
            _repoSaleLineItem.Update(sli);
            return sli;
        }

        public void DeleteSaleLineItem(int id)
        {
            _repoSaleLineItem.Delete(id);
        }
        #endregion

        public IEnumerable<Customer> GetAllCustomers()
        {
            var list = _repoCustomer.GetAll();
            return list;
        }

        public IEnumerable<EmployeeInPosition> GetAllEmployees()
        {
            var list = _repoEmployeeInPosition.GetEmployeeInSalePosition().Where(s => s.Position.Name == "Sales").ToList();
            return list;
        }

        public List<KPIDTO> GetGrossSaleComp()
        {
            var employees = _repoEmployeeInPosition.GetEmployeeInSalePosition().Where(s => s.Position.Name == "Sales").ToList();
            var empDTO = new List<KPIDTO>();
            foreach (var e in employees)
            {
                var totalSales = 0;
                var totalLeads = 0;
                decimal grossProfit = 0;
                foreach (var spl in e.SalePositionLeads)
                {
                    if (spl.FinalisedSale == true)
                    {
                        totalSales++;
                        var sliList = spl.SaleLead.Sale.SaleLineItems;
                        foreach (var s in sliList)
                        {
                            grossProfit = grossProfit + (s.Amount * s.Qty);
                        }
                    }
                    else if(spl.FinalisedSale == false)
                    {
                        totalLeads++;
                    }

                }
                empDTO.Add(new KPIDTO { Employee = new EmployeeDTO { EmployeeId = e.Id, EmployeeName = e.Employee.Lastname + ", " + e.Employee.Firstname }, GrossProfit = grossProfit / 100000, TotalSales = totalSales, TotalLeads = totalLeads });
            }

            return empDTO;
        }

        public List<KPIDTO> GetGrossSaleCompDate()
        {
            var spls = _repoSalePositionLead.GetAll();
            var empDTO = new List<KPIDTO>();
            foreach (var s in spls)
            {
                decimal grossProfit = 0;

                if(s.FinalisedSale == true)
                {
                    var sliList = s.SaleLead.Sale.SaleLineItems;
                    foreach (var sli in sliList)
                    {
                            grossProfit = grossProfit + (sli.Amount * sli.Qty);
                    }
                    empDTO.Add(new KPIDTO {Date = s.SaleLead.Sale.Date, Employee = new EmployeeDTO { EmployeeId = s.EmployeeInSalePosition.Employee.Id, EmployeeName = s.EmployeeInSalePosition.Employee.Lastname + ", " + s.EmployeeInSalePosition.Employee.Firstname }, GrossProfit = grossProfit });

                }
            }

            return empDTO;
        }

        public List<KPIDTO> GetCusSaleComp()
        {
            var customers = _repoCustomer.GetAll();
            var cusDTO = new List<KPIDTO>();
            foreach (var c in customers)
            {
                var totalSales = 0;
                var totalLeads = 0;
                decimal grossProfit = 0;
                var sales = _repoSalePositionLead.AsQueryable().Where(x => x.SaleLead.CustomerId == c.Id).ToList();

                foreach (var spl in sales)
                {
                    if (spl.FinalisedSale == true)
                    {
                        totalSales++;
                        var sliList = spl.SaleLead.Sale.SaleLineItems;
                        foreach (var s in sliList)
                        {
                            grossProfit = grossProfit + (s.Amount * s.Qty);
                        }
                    }
                    else if (spl.FinalisedSale == false)
                    {
                        totalLeads++;
                    }

                }
                cusDTO.Add(new KPIDTO { Customer = new CustomerDTO { CustomerId = c.Id, CustomerName = c.Name }, GrossProfit = grossProfit / 100000, TotalSales = totalSales, TotalLeads = totalLeads });
            }

            return cusDTO;
        }

    }


    public class CryptoRandom : RandomNumberGenerator
    {
        private static RandomNumberGenerator r;
        ///<summary>
        /// Creates an instance of the default implementation of a cryptographic random number generator that can be used to generate random data.
        ///</summary>
        public CryptoRandom()
        {
            r = RandomNumberGenerator.Create();
        }
        ///<summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        ///</summary>
        ///<param name=”buffer”>An array of bytes to contain random numbers.</param>
        public override void GetBytes(byte[] buffer)
        {
            r.GetBytes(buffer);
        }
        ///<summary>
        /// Returns a random number between 0.0 and 1.0.
        ///</summary>
        public double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }
        ///<summary>
        /// Returns a random number within the specified range.
        ///</summary>
        ///<param name=”minValue”>The inclusive lower bound of the random number returned.</param>
        ///<param name=”maxValue”>The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        public int Next(int minValue, int maxValue)
        {
            var value = maxValue - minValue - 1;
            return (int)Math.Round(NextDouble() * (value)) + minValue;
        }
        ///<summary>
        /// Returns a nonnegative random number.
        ///</summary>
        public int Next()
        {
            return Next(0, Int32.MaxValue);
        }
        ///<summary>
        /// Returns a nonnegative random number less than the specified maximum
        ///</summary>
        ///<param name=”maxValue”>The inclusive upper bound of the random number returned. maxValue must be greater than or equal 0</param>
        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }
    }
}
