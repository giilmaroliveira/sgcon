using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;

namespace SgConAPI.Repository
{
    internal class CondominioRepository : BaseDataService<Condominio>, ICondominioRepository
    {
        public CondominioRepository(SgConContext context) :base(context)
        {

        }
    }
}
