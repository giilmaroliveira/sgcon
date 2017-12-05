using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository.Contracts
{
    public interface ICommonAreaScheduleRepository : IBaseDataService<CommonAreaSchedule>
    {
        IQueryable<CommonAreaSchedule> GetByCommonAreaId(int id, DateTime date);
        IQueryable<CommonAreaSchedule> GetUserSchedule(int apartmentId);
    }
}
