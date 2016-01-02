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
    public class CompanyService :ICompanyService
    {
        private readonly ICompanyRepository _repoCompany;

        public CompanyService(ICompanyRepository repoCompany)
        {
            _repoCompany = repoCompany; 
        }
        public Company Create(string name, string abn)
        {
            var company = new Company { Name = name, ABN= abn};
            _repoCompany.Add(company);
            return company; 
        }


        public IQueryable<Company> AsQueryable()
        {
            return _repoCompany.AsQueryable(); 
        }
    }
}
