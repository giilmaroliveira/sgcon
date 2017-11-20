using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Linq;
namespace SgConAPI.Business
{
    internal class ResidentBusinessService : BaseBusinessService<IResidentRepository, Resident>, IResidentBusinessService
    {
        private readonly IResidentRepository _residentRepository;
        public ResidentBusinessService(IResidentRepository repository) : base(repository)
        {
            _residentRepository = repository;
        }

        public Resident GetById(int id)
        {
            return Repository.Get(id);
        }

        public Resident CreateResident(Resident model)
        {
            var result = Repository.Post(model);

            return result;
        }

        public Resident UpdateResident(Resident model, int id)
        {
            var result = Repository.Update(model);

            return result;
        }

        public void DeleteResident(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<Resident> GetAll(string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }

        public Resident GetResidentByEmailOrUsername(ApplicationUser loginUser)
        {
            return _residentRepository.GetResidentByEmailOrUsername(loginUser);
        }
    }
}
