using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E
{
    public class EfCustomerRepository : IMockCustomerRepository
    {
        private HRMSDBContext _context;

        public EfCustomerRepository(HRMSDBContext context)
        {
            _context = context;
        }

        //"Harold - Please don't delete"
        

        /// <summary>
        /// Get all Customers Method
        /// Using IEnumerable
        /// </summary>
        /// <returns> All Customers</returns>
        public IEnumerable<Domain.Models.Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        /// <summary>
        /// Get Customer by Id 
        /// Using a simple First or Default LINQ Lambda
        /// Also handle exception if now customer is input
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Domain.Models.Customer Get(int id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                throw new InvalidOperationException("The customer does not exist");
            }

            return customer;
        }

        public void Add(Domain.Models.Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        /// <summary>
        /// Update uses context to "listen" for any change then
        /// saves changes to the State of customer
        /// </summary>
        /// <param name="customer"></param>
        public void Update(Domain.Models.Customer customer)
        {
            if (_context.Entry(customer).State == System.Data.Entity.EntityState.Modified)
            {
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Method
        /// This removes it to both context and DB (be careful)
        /// </summary>
        /// <param name="customer"></param>
        public void Delete(Domain.Models.Customer customer)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
