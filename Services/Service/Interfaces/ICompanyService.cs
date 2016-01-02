using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.Interfaces
{
    public interface ICompanyService
    {
        Company Create(string name, string abn);

        IQueryable<Company> AsQueryable();
    }
}
