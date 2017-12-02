using Microsoft.EntityFrameworkCore;
using SgConAPI.EntityFramework;
using SgConAPI.EntityFramework.QueryFilter;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SgConAPI.Repository
{
    internal class CondominiumRepository : BaseDataService<Condominium>, ICondominiumRepository
    {
        private readonly IAddressRepository _addressRepository;
        public CondominiumRepository(
            SgConContext context,
            IAddressRepository addressRepository) : base(context)
        {
            _addressRepository = addressRepository;
        }

        public override Condominium Get(int id)
        {
            return (from c in base.Entities
                        .Include(c => c.Address)
                        .Include(c => c.Address.AddressType)
                        where c.Id == id
                        select c).FirstOrDefault();   
        }

        public override IQueryable<Condominium> GetAll(Dictionary<string, object> filters = null)
        {

            IQueryable<Condominium> condominius = base.Entities.Include(a => a.Address);

            if (filters != null)
            {
                var qFilter = new QueryFilterFactory<Condominium>();
                foreach (var tuple in filters)
                {
                    condominius = qFilter.QueryFieldContains(condominius, tuple.Key, tuple.Value);
                }
            }

            return condominius;
        }

        public override Condominium Update(Condominium entity)
        {
            var address = _addressRepository.Update(entity.Address);
            entity.Address = address;
            return base.Update(entity);
            
        }
    }
}
