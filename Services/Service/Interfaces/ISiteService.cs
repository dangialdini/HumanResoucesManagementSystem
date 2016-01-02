using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface ISiteService
    {
        Site CreateSite(int customerId, int addressId, string name, string phone, string email, bool franchise, bool headQuarter);
        Site UpdateDetails(int id, string name, string phone, string email, bool franchise, bool headQuarters);
        void DeleteSite(int id);
        IQueryable<Site> AsQueryable();
    }
}
