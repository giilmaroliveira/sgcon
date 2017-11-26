using SgConAPI.Models.Base;
using System;

namespace SgConAPI.Models
{
    public class CommonAreaSchedule : BaseModel
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }
        public int CommonAreaId { get; set; }
        public CommonArea CommonArea { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public Boolean Used { get; set; }
    }
}
