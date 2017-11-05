using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class House : BaseModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
    }
}
