using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Condominio : BaseModel
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Cnpj { get; set; }
        public int NumPredios { get; set; }
        
        public ICollection<Predio> Predios { get; set; }
    }
}
