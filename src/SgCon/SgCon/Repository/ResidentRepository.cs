using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;

namespace SgConAPI.Repository
{
    internal class ResidentRepository : BaseDataService<Resident>, IResidentRepository
    {
        public ResidentRepository(SgConContext context) : base(context)
        {

        }
    }
}
