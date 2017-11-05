using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business.Contracts
{
    public interface ICondominioBusinessService : IBaseBusinessService<ICondominioRepository, Condominio>
    {
        Condominio GetById(int id);
        Condominio CreateCondominio(Condominio model);
        Condominio UpdateCondominio(Condominio model, int id);
        void DeleteCondominio(int id);
    }
}
