using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Business.Contracts
{
    public interface IResidentBusinessService : IBaseBusinessService<IResidentRepository, Resident>
    {
        Resident GetById(int id);
        Resident CreateResident(Resident model);
        Resident UpdateResident(Resident model, int id);
        void DeleteResident(int id);
        IQueryable<Resident> GetAll(string filters);
    }
}
