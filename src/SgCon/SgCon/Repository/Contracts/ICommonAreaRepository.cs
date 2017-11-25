using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository.Contracts
{
    public interface ICommonAreaRepository : IBaseDataService<CommonArea>
    {
        IQueryable<CommonArea> GetByCondominiumId(int id);
    }
}
