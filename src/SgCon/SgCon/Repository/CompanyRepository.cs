using Microsoft.EntityFrameworkCore;
using SgConAPI.EntityFramework;
using SgConAPI.EntityFramework.QueryFilter;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository
{
    internal class CompanyRepository : BaseDataService<Company>, ICompanyRepository
    {
        private readonly IAddressRepository _addressRepository;
        public CompanyRepository(SgConContext context, IAddressRepository addressRepository) : base(context)
        {
            _addressRepository = addressRepository;
        }

        public override Company Get(int id)
        {
            return (from c in base.Entities
                        .Include(c => c.Address)
                        .Include(c => c.Address.AddressType)
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        public override IQueryable<Company> GetAll(Dictionary<string, object> filters = null)
        {

            IQueryable<Company> companies = base.Entities.Include(a => a.Address);

            if (filters != null)
            {
                var qFilter = new QueryFilterFactory<Company>();
                foreach (var tuple in filters)
                {
                    companies = qFilter.QueryFieldContains(companies, tuple.Key, tuple.Value);
                }
            }

            return companies;
        }

        public override Company Update(Company entity)
        {
            var address = _addressRepository.Update(entity.Address);
            entity.Address = address;
            return base.Update(entity);

        }
    }
}
