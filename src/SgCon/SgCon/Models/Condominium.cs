using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Condominium : BaseModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public string Cnpj { get; set; }
        public int HouseNumber { get; set; }
        public ICollection<House> House { get; set; }
    }
}
