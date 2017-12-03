using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace SgConAPI.Business
{
    internal class ApartmentBusinessService : BaseBusinessService<IApartmentRepository, Apartment>, IApartmentBusinessService
    {
        private IApartmentRepository _apartmentRepository;
        public ApartmentBusinessService(IApartmentRepository repository) : base(repository)
        {
            _apartmentRepository = repository;
        }

        public Apartment GetById(int id)
        {
            return Repository.Get(id);
        }

        public Apartment CreateApartment(Apartment model)
        {
            var result = Repository.Post(model);

            return result;
        }

        public Apartment UpdateApartment(Apartment model, int id)
        {
            var result = Repository.Update(model);

            return result;
        }

        public void DeleteApartment(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<Apartment> GetAll(string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }

        public IQueryable<Apartment> GetByTowerId(int id)
        {
            var result = _apartmentRepository.GetByTowerId(id);

            return result;
        }
    }
}
