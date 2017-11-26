using Newtonsoft.Json;
using SgConAPI.Models.Base;
using SgConAPI.Models.Contracts;
using SgConAPI.Utils;
using SgConAPI.Utils.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class CommonArea : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int CondominiumId { get; set; }
        public int IntervalTime { get; set; }
        public Condominium Condominium { get; set; }
        public IQueryable<CommonAreaSchedule> CommonAreaSchedule { get; set; }

    }
}
