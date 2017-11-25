using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace SgConAPI.Business.Contracts
{
    public interface ICommonAreaBusinessService : IBaseBusinessService<ICommonAreaRepository, CommonArea>
    {
        CommonArea GetById(int id);
        CommonArea CreateCommonArea(CommonArea model);
        CommonArea UpdateCommonArea(CommonArea model, int id);
        void DeleteCommonArea(int id);
        IQueryable<CommonArea> GetAll(string filters);
        IQueryable<CommonArea> GetByCondominiumId(int id);
    }
}
