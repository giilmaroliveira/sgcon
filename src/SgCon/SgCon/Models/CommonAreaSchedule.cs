using Newtonsoft.Json;
using SgConAPI.Models.Base;
using SgConAPI.Utils;
using System;

namespace SgConAPI.Models
{
    public class CommonAreaSchedule : BaseModel
    {
        public int ApartmentId { get; set; }
        [JsonIgnore]
        public Apartment Apartment { get; set; }
        public int CommonAreaId { get; set; }
        [JsonIgnore]
        public CommonArea CommonArea { get; set; }
        [JsonConverter(typeof(CustomDateConverter))]
        public DateTime Date { get; set; }
        //public TimeSpan StartTime { get; set; }
        //public TimeSpan EndTime { get; set; }
        public Boolean Used { get; set; }
        public int ScheduleId { get; set; }
    }
}
