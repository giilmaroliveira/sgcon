using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Business
{
    internal class HouseBusinessService : BaseBusinessService<IHouseRepository, House>, IHouseBusinessService
    {
        public HouseBusinessService(IHouseRepository repository) : base(repository)
        {

        }

        public House GetById(int id)
        {
            return Repository.Get(id);
        }

        public House CreateHouse(House model)
        {
            var result = Repository.Post(model);

            return result;
        }

        public House UpdateHouse(House model, int id)
        {
            var result = Repository.Update(model);

            return result;
        }

        public void DeleteHouse(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<House> GetAll(string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }
    }
}
