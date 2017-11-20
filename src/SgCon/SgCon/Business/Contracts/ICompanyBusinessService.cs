using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SgConAPI.Business.Contracts
{
    public interface ICompanyBusinessService : IBaseBusinessService<ICompanyRepository, Company>
    {
        Company GetById(int id);
        Company CreateCompany(Company model);
        Company UpdateCompany(Company model, int id);
        void DeleteCompany(int id);
        IQueryable<Company> GetAll(string filters);
    }
}
