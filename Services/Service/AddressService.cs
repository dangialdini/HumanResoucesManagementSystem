using Services.Repositories.Interfaces;
using Services.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Models;

namespace Services.Service
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repoAddress;
        private readonly ISuburbRepository _repoSuburb;

        public AddressService(IAddressRepository repoAddress, ISuburbRepository repoSuburb)
        {
            _repoAddress = repoAddress;
            _repoSuburb = repoSuburb;
        }
        public Address Create(int suburbId, string street1, string street2 = "")
        {
            var address = new Address { SuburbId = suburbId, Street1 = street1, Street2 = street2 };
            _repoAddress.Add(address);
            return address;
        }

        //Update Address Details:

        public Address UpdateDetails(int id, string street1, string street2, int suburbId)
        {
            var address = _repoAddress.Get(id);


            address.Id = id;
            address.Street1 = street1;
            address.Street2 = street2;
            address.SuburbId = suburbId;

            _repoAddress.Update(address);

            return address;
        }
    }
}
