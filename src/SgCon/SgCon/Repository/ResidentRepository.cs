using Microsoft.EntityFrameworkCore;
using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Repository
{
    internal class ResidentRepository : BaseDataService<Resident>, IResidentRepository
    {
        public ResidentRepository(SgConContext context) : base(context)
        {

        }

        public Resident GetResidentByEmailOrUsername(ApplicationUser loginUser)
        {
            return (from r in Entities
                    .AsNoTracking()
                    .Include(r => r.Profile)
                    .Include(r => r.Profile.Role)
                    where ((r.UserName == loginUser.UserName || r.Email == loginUser.UserName))
                    select r).FirstOrDefault();
        }

        public Resident GetResidentByUserName(string userName)
        {
            return base.Entities
                .AsNoTracking()
                .Include(r => r.Apartment)
                .Include(r => r.Apartment.Tower)
                .Include(r => r.Apartment.Tower.Condominium)
                .Include(r => r.Profile)
                .Include(p => p.Profile.ProfilePolicies)
                .ThenInclude(pp => pp.Policy)
                .Include(p => p.Profile.Role)
                .FirstOrDefault(r => r.UserName == userName);
        }

        public override Resident Get(int id)
        {
            return (from c in base.Entities
                        .Include(r => r.Apartment)
                        .Include(r => r.Apartment.Tower)
                        .Include(r => r.Apartment.Tower.Condominium)
                    where c.Id == id
                    select c).FirstOrDefault();
        }
    }
}
