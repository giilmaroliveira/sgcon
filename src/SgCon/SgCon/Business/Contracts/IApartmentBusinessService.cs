using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Linq;

namespace SgConAPI.Business.Contracts
{
    public interface IApartmentBusinessService : IBaseBusinessService<IApartmentRepository, Apartment>
    {
        Apartment GetById(int id);
        Apartment CreateApartment(Apartment model);
        Apartment UpdateApartment(Apartment model, int id);
        void DeleteApartment(int id);
        IQueryable<Apartment> GetAll(string filters);
    }
}
