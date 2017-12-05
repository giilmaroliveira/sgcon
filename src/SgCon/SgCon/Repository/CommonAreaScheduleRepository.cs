using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository
{
    internal class CommonAreaScheduleRepository : BaseDataService<CommonAreaSchedule>, ICommonAreaScheduleRepository
    {
        public CommonAreaScheduleRepository(SgConContext context) : base(context)
        {

        }

        public IQueryable<CommonAreaSchedule> GetByCommonAreaId(int id, DateTime date)
        {
            return (from c in base.Entities
                    where c.CommonAreaId == id && c.Date == date
                    select c);
        }
    }
}
