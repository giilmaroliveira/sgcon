using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Business.Contracts
{
    public interface ITowerBusinessService : IBaseBusinessService<ITowerRepository, Tower>
    {
        Tower GetById(int id);
        Tower CreateTower(Tower model);
        Tower UpdateTower(Tower model, int id);
        void DeleteTower(int id);
        IQueryable<Tower> GetAll(string filters);
        IQueryable<Tower> GetByCondominiumId(int id);
    }
}
