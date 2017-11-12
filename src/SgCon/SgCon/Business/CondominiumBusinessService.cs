using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Linq;

namespace SgConAPI.Business
{
    internal class CondominiumBusinessService : BaseBusinessService<ICondominiumRepository, Condominium>, ICondominiumBusinessService
    {
        public CondominiumBusinessService(ICondominiumRepository repository) : base(repository)
        {

        }

        public Condominium GetById(int id)
        {
            return Repository.Get(id);
        }

        public Condominium CreateCondominium(Condominium model)
        {
            model.CreatedBy = "Sistema";

            var result = Repository.Post(model);

            return result;
        }

        public Condominium UpdateCondominium(Condominium model, int id)
        {

            model.UpdatedBy = "Sistema";

            var result = Repository.Update(model);

            return result;
        }

        public void DeleteCondominium(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<Condominium> GetAll (string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }
    }
}
