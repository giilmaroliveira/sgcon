using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business.Contracts
{
    public interface ICommonAreaScheduleBusinessService : IBaseBusinessService<ICommonAreaScheduleRepository, CommonAreaSchedule>
    {
        CommonAreaSchedule GetById(int id);
        CommonAreaSchedule CreateSchedule(CommonAreaSchedule model);
        CommonAreaSchedule UpdateSchedule(CommonAreaSchedule model, int id);
        void DeleteSchedule(int id);
        IQueryable<CommonAreaSchedule> GetAll(string filters);
    }
}
