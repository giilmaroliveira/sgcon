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
    internal class EmployeeRepository : BaseDataService<Employee>, IEmployeeRepository
    {
        private readonly IAddressRepository _addressRepository;
        public EmployeeRepository(SgConContext context, IAddressRepository addressRepository) : base(context)
        {
            _addressRepository = addressRepository;
        }

        public Employee GetEmployeeByEmailOrUsername(ApplicationUser loginUser)
        {
            return (from e in base.Entities
                    .AsNoTracking()
                    .Include(e => e.Profile)
                    .Include(e => e.Profile.Role)
                    where ((e.UserName == loginUser.UserName || e.Email == loginUser.UserName))
                    select e).FirstOrDefault();
        }

        public Employee GetEmployeeByUserName(string userName)
        {
            return base.Entities.AsNoTracking().Include(e => e.Profile)
                                    .Include(p => p.Profile.ProfilePolicies)
                                    .ThenInclude(pp => pp.Policy)
                                    .Include(p => p.Profile.Role)
                                    .FirstOrDefault(e => e.UserName == userName);
        }

        public override Employee Get(int id)
        {
            return (from c in base.Entities
                        .Include(c => c.Address)
                        .Include(c => c.Address.AddressType)
                    where c.Id == id
                    select c).FirstOrDefault();
        }

        public override IQueryable<Employee> GetAll(Dictionary<string, object> filters = null)
        {

            IQueryable<Employee> employees = base.Entities.Include(a => a.Address);

            if (filters != null)
            {
                var qFilter = new QueryFilterFactory<Employee>();
                foreach (var tuple in filters)
                {
                    employees = qFilter.QueryFieldContains(employees, tuple.Key, tuple.Value);
                }
            }

            return employees;
        }

        public override Employee Update(Employee entity)
        {
            var address = _addressRepository.Update(entity.Address);
            entity.Address = address;
            return base.Update(entity);

        }
    }
}
