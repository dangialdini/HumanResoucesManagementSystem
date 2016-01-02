using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn.Team_E
{
    public interface IMockSiteRepository
    {
        //Use Method signatures only for Interfaces
        IEnumerable<Domain.Models.Site> GetAll();
        Domain.Models.Site Get(int id);
        void Add(Domain.Models.Site site);
        void Update(Domain.Models.Site site);
        void Delete(Domain.Models.Site site);
        
    }
}
