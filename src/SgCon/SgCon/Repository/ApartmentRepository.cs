using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;

namespace SgConAPI.Repository
{
    internal class ApartmentRepository : BaseDataService<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(SgConContext context) : base(context)
        {

        }
    }
}
