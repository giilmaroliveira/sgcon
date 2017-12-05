using Microsoft.EntityFrameworkCore;
using SgConAPI.EntityFramework;
using SgConAPI.EntityFramework.QueryFilter;
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

        public IQueryable<CommonAreaSchedule> GetUserSchedule(int apartmentId)
        {
            return (from c in base.Entities
                    // .Include(c => c.CommonArea)
                    where c.ApartmentId == apartmentId && c.Date >= DateTime.Now
                    select c);
        }

        public override IQueryable<CommonAreaSchedule> GetAll(Dictionary<string, object> filters = null)
        {

            IQueryable<CommonAreaSchedule> schedules = base.Entities; // .Include(a => a.CommonArea);

            if (filters != null)
            {
                var qFilter = new QueryFilterFactory<CommonAreaSchedule>();
                foreach (var tuple in filters)
                {
                    schedules = qFilter.QueryFieldContains(schedules, tuple.Key, tuple.Value);
                }
            }

            return schedules;
        }
    }
}
