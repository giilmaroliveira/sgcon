using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SgConAPI.Business
{
    internal class TowerBusinessService : BaseBusinessService<ITowerRepository, Tower>, ITowerBusinessService
    {
        private ITowerRepository _towerRepository;
        private IApartmentRepository _apartmentRepository;
        public TowerBusinessService(
            ITowerRepository repository,
            IApartmentRepository apartmentRepository) : base(repository)
        {
            _towerRepository = repository;
            _apartmentRepository = apartmentRepository;
        }

        public Tower GetById(int id)
        {
            return Repository.Get(id);
        }

        public Tower CreateTower(Tower model)
        {
            var result = Repository.Post(model);

            return result;
        }

        public Tower UpdateTower(Tower model, int id)
        {
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

        public IQueryable<Tower> GetByCondominiumId(int id)
        {
            var result = _towerRepository.GetByCondominiumId(id);

            return result;
        }

        public List<Apartment> GenerateApartments(Tower tower)
        {
            List<Apartment> listApartments = new List<Apartment>();

            for (var i = 1; i <= tower.QuantityByFloor; i++)
            {
                Apartment apartment = new Apartment
                {
                    Number = tower.Floor.ToString() + i.ToString(),
                    Floor = tower.Floor.ToString(),
                    Active = true,
                    TowerId = tower.Id,
                    CreatedAt = DateTime.Now
                };
                listApartments.Add(apartment);
            }

            _apartmentRepository.CreateRange(listApartments);

            return listApartments;            
        }
    }
}
