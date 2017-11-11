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
        public string Block { get; set; }
        public int CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
        public ICollection<House> House { get; set; }
    }
}
