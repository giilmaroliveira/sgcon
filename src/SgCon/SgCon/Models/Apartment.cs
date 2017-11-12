using SgConAPI.Models.Base;
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
        public int Number { get; set; }
        [Required]
        public string Floor { get; set; }
        public int TowerId { get; set; }
        public Tower Tower { get; set; }
    }
}
