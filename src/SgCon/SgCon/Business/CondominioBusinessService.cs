using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business
{
    internal class CondominioBusinessService : BaseBusinessService<ICondominioRepository, Condominio>, ICondominioBusinessService
    {
        public CondominioBusinessService(ICondominioRepository repository) : base(repository)
        {

        }

        public Condominio GetById(int id)
        {
            return Repository.Get(id);
        }

        public Condominio CreateCondominio(Condominio model)
        {
            var result = Repository.Post(model);

            return result;
        }

        public Condominio UpdateCondominio(Condominio model, int id)
        {
            var result = Repository.Update(model);

            return result;
        }

        public void DeleteCondominio(int id)
        {
            Repository.Delete(id);
        }
    }
}
