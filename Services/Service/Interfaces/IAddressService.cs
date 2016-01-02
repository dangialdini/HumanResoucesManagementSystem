using Domain.Models;
using System;

namespace Services.Service.Interfaces
{
    public interface IAddressService
    {
        Address Create(int suburbId, string street1, string street2 = "");
        Address UpdateDetails(int id, string street1, string street2, int suburbId);
    }
}
