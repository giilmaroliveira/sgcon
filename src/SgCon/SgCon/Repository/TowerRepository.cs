using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;

namespace SgConAPI.Repository
{
    internal class TowerRepository : BaseDataService<Tower>, ITowerRepository
    {
        public TowerRepository(SgConContext context) : base(context)
        {

        }
    }
}
