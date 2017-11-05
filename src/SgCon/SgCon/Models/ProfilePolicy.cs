using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class ProfilePolicy : BaseModel
    {
        [Key, Column(Order = 0)]
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        [Key, Column(Order = 1)]
        public int PolicyId { get; set; }
        public virtual Policy Policy { get; set; }
    }
}
