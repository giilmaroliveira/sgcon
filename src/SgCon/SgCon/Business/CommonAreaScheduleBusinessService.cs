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
    internal class CommonAreaScheduleBusinessService : BaseBusinessService<ICommonAreaScheduleRepository, CommonAreaSchedule>, ICommonAreaScheduleBusinessService
    {
        private readonly ICommonAreaScheduleRepository _commonAreaScheduleRepository;
        public CommonAreaScheduleBusinessService(ICommonAreaScheduleRepository repository) : base(repository)
        {
            _commonAreaScheduleRepository = repository;
        }

        public CommonAreaSchedule GetById(int id)
        {
            return Repository.Get(id);
        }

        public CommonAreaSchedule CreateSchedule(CommonAreaSchedule model)
        {
            var result = Repository.Post(model);

            return result;
        }

        public CommonAreaSchedule UpdateSchedule(CommonAreaSchedule model, int id)
        {
            var result = Repository.Update(model);

            return result;
        }

        public void DeleteSchedule(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<CommonAreaSchedule> GetAll(string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }

        public IQueryable<CommonAreaSchedule> GetByCommonAreaId(int id, string date)
        {
            DateTime convertedDate = Convert.ToDateTime(date);

            var result = _commonAreaScheduleRepository.GetByCommonAreaId(id, convertedDate);

            return result;
        }

        public IQueryable<CommonAreaSchedule> GetUserSchedule(int apartmentId)
        {
            var result = _commonAreaScheduleRepository.GetUserSchedule(apartmentId);

            return result;
        }
    }   
}
