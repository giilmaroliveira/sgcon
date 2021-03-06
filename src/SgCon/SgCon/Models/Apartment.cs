﻿using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Apartment : BaseModel
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string Floor { get; set; }
        public int TowerId { get; set; }
        public Tower Tower { get; set; }
        public IQueryable<CommonAreaSchedule> CommonAreaSchedule { get; set; }
        public ICollection<Resident> Resident { get; set; }
    }
}
