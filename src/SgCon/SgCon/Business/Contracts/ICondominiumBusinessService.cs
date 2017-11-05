using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business.Contracts
{
    public interface ICondominiumBusinessService : IBaseBusinessService<ICondominiumRepository, Condominium>
    {
        Condominium GetById(int id);
        Condominium CreateCondominium(Condominium model);
        Condominium UpdateCondominium(Condominium model, int id);
        void DeleteCondominium(int id);
    }
}
