using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Business.Contracts
{
    public interface ICondominiumBusinessService : IBaseBusinessService<ICondominiumRepository, Condominium>
    {
        Condominium GetById(int id);
        Condominium CreateCondominium(Condominium model);
        Condominium UpdateCondominium(Condominium model, int id);
        void DeleteCondominium(int id);
        IQueryable<Condominium> GetAll(string filters);
    }
}
