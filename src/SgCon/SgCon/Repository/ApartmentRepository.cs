using System.Linq;
using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace SgConAPI.Repository
{
    internal class ApartmentRepository : BaseDataService<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(SgConContext context) : base(context)
        {

        }

        public override Apartment Get(int id)
        {
            return (from a in base.Entities
                    .Include(a => a.Tower)
                    .Include(a => a.Tower.Condominium)
                    where a.DeletedAt == null
                    && a.Id == id
                    select a).OrderBy(x => x.Number).FirstOrDefault();
        }

        public IQueryable<Apartment> GetByTowerId(int id)
        {
            return (from a in base.Entities
                    .Include(a => a.Tower)
                    where a.DeletedAt == null
                    && a.TowerId == id
                    select a).OrderBy(x => x.Number);
        }
    }
}
