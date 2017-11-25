using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository
{
    internal class CommonAreaRepository : BaseDataService<CommonArea>, ICommonAreaRepository
    {
        public CommonAreaRepository(SgConContext context) : base(context)
        {

        }

        public IQueryable<CommonArea> GetByCondominiumId(int id)
        {
            return (from t in base.Entities
                    where t.DeletedAt == null
                    && t.CondominiumId == id
                    select t);
        }
    }
}
