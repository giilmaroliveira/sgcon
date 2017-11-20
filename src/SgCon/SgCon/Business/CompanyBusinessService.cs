using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SgConAPI.Business
{
    internal class CompanyBusinessService : BaseBusinessService<ICompanyRepository, Company>, ICompanyBusinessService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyBusinessService(ICompanyRepository repository) : base(repository)
        {
            _companyRepository = repository;
        }

        public Company GetById(int id)
        {
            return Repository.Get(id);
        }

        public Company CreateCompany(Company model)
        {
            var result = Repository.Post(model);

            return result;
        }

        public Company UpdateCompany(Company model, int id)
        {
            var result = Repository.Update(model);

            return result;
        }

        public void DeleteCompany(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<Company> GetAll(string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }
    }
}
