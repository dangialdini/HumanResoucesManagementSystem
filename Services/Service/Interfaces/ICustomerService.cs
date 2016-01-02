using Domain.Models;
using System;

namespace Services.Service.Interfaces
{
    public interface ICustomerService
    {
        Customer RegisterCustomer(int companyId, string name, string abn, bool franchise, string phone, string email);
        Customer UpdateDetails(int id, string name, string abn, bool franchise, string phone, string email);
        void DeleteCustomer(int id);

        //POSSIBLE UPDATE: -Customer ChangeStatus (need "bool active" in customer table- DB);
    }
}
