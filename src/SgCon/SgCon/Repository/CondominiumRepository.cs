using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;

namespace SgConAPI.Repository
{
    internal class CondominiumRepository : BaseDataService<Condominium>, ICondominiumRepository
    {
        public CondominiumRepository(SgConContext context) :base(context)
        {

        }
    }
}
