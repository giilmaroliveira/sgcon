using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Business.Contracts
{
    public interface IHouseBusinessService : IBaseBusinessService<IHouseRepository, House>
    {
        House GetById(int id);
        House CreateHouse(House model);
        House UpdateHouse(House model, int id);
        void DeleteHouse(int id);
        IQueryable<House> GetAll(string filters);
    }
}
