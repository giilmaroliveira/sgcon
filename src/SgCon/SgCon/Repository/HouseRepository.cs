using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;

namespace SgConAPI.Repository
{
    internal class HouseRepository : BaseDataService<House>, IHouseRepository
    {
        public HouseRepository(SgConContext context) : base(context)
        {

        }
    }
}
