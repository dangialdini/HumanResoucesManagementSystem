using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E
{
    public interface IMockCustomerRepository
    {
        //Use Method signatures only for Interfaces
        IEnumerable<Domain.Models.Customer> GetAll();
        Domain.Models.Customer Get(int id);
        void Add(Domain.Models.Customer customer);
        void Update(Domain.Models.Customer customer);
        void Delete(Domain.Models.Customer customer);
    }
}
