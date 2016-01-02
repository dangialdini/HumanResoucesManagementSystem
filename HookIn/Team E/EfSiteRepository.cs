using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E
{
	//"Harold - Please don't delete- Change to sharp Repository- dont use models"

    //class EfSiteRepository : IMockSiteRepository
    //{
    //    private HRMSDBContext _context;

    //    public EfSiteRepository(HRMSDBContext context)
    //    {
    //        _context = context;
    //    }
    //    /// <summary>
    //    /// Get all Sites Method
    //    /// Using IEnumerable 
    //    /// </summary>
    //    /// <returns>All Sites</returns>
    //    public IEnumerable<Domain.Models.Site> GetAll()
    //    {
    //        return _context.Sites.ToList();
    //    }
		
    //    public Domain.Models.Site Get(int id)
    //    {
    //        var site = _context.Sites.FirstOrDefault(s => s.Id == id);
    //        if (site == null)
    //        {
    //        throw new InvalidOperationException("The site does exist");	 
    //        }
    //        return site;
    //    }

    //    public void Add(Domain.Models.Site site)
    //    {
    //        _context.Sites.Add(site);
    //        _context.SaveChanges();
    //    }

    //    /// <summary>
    //    /// Update uses context to "listen" for any change then
    //    /// saves changes to the State of site
    //    /// </summary>
    //    /// <param name="customer"></param>
    //    public void Update(Domain.Models.Site site)
    //    {
    //        if( _context.Entry(site).State == System.Data.Entity.EntityState.Modified)
    //        {
    //            _context.SaveChanges();
    //        }
    //    }
    //    /// <summary>
    //    /// Delete Method
    //    /// This removes it to both context and DB (be careful)
    //    /// </summary>
    //    /// <param name="customer"></param>
    //    public void Delete(Domain.Models.Customer customer)
    //    {
    //        _context.Customers.Remove(customer);
    //        _context.SaveChanges();
    //    }

    //}
}
