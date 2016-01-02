using Domain.Models;
using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class SiteService : ISiteService
    {
        private readonly ISiteRepository _repoSite;
        private readonly IAddressRepository _repoAddress;
        private readonly ICustomerRepository _repoCustomer;

        public SiteService(ISiteRepository repoSite, IAddressRepository repoAddress, ICustomerRepository repoCustomer)
        {
            _repoSite = repoSite;
            _repoAddress = repoAddress;
            _repoCustomer = repoCustomer;
        }

        //Create Site:
        public Site CreateSite(int customerId, int addressId, string name, string phone, string email, bool franchise, bool headQuarters)
        {
            var customer = _repoCustomer.Get(customerId);
            var address = _repoAddress.Get(addressId);
            var site = new Site
            {
                CustomerId = customerId,
                AddressId = addressId,
                Name = name,
                Phone = phone,
                Email = email,
                Franchise = franchise,
                HeadQuarters = headQuarters
            };
            _repoSite.Add(site);
            return site;
        }

        //Update Details:

        public Site UpdateDetails(int id, string name, string phone, string email, bool franchise, bool headQuarters)
        {
            var site = _repoSite.Get(id);


            site.Name = name;
            site.Phone = phone;
            site.Email = email;
            site.Franchise = franchise;
            site.HeadQuarters = headQuarters;

            _repoSite.Update(site);

            return site;
        }

        //Delete Site:
        public void DeleteSite(int id)
        {
            var site = _repoSite.Get(id);

            _repoSite.Delete(site);
        }

        public IQueryable<Site> AsQueryable()
        {
            return _repoSite.AsQueryable();
        }


        //void DeleteSite(int id)
        //{
        //    _repoSite.Delete(id);
        //}

        public IAddressRepository repoAddress { get; set; }
    }
}
