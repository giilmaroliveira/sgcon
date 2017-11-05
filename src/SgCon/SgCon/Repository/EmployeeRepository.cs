using Microsoft.EntityFrameworkCore;
using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Repository
{
    internal class EmployeeRepository : BaseDataService<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SgConContext context) : base(context)
        { }

        public Employee GetEmployeeByUserName(string userName)
        {
            return base.Entities.AsNoTracking().Include(e => e.Profile)
                                    .Include(p => p.Profile.ProfilePolicies)
                                    .ThenInclude(pp => pp.Policy)
                                    .Include(p => p.Profile.Role)
                                    .FirstOrDefault(e => e.UserName == userName);
        }
    }
}
