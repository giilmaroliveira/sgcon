using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Business
{
    internal class TowerBusinessService : BaseBusinessService<ITowerRepository, Tower>, ITowerBusinessService
    {
        public TowerBusinessService(ITowerRepository repository) : base(repository)
        {

        }

        public Tower GetById(int id)
        {
            return Repository.Get(id);
        }

        public Tower CreateTower(Tower model)
        {
            model.CreatedBy = "Sistema";

            var result = Repository.Post(model);

            return result;
        }

        public Tower UpdateTower(Tower model, int id)
        {
            model.UpdatedBy = "Sistema";

            var result = Repository.Update(model);

            return result;
        }

        public void DeleteTower(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<Tower> GetAll(string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }
    }
}
