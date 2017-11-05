using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Role : BaseModel
    {
        [Required]
        public string Description { get; set; }

    }
}
