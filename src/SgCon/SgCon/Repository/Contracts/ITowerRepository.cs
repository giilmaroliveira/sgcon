using SgConAPI.EntityFramework;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository.Contracts
{
    public interface ITowerRepository : IBaseDataService<Tower>
    {
        IQueryable<Tower> GetByCondominiumId(int id);
    }
}
