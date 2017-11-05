using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Predio : BaseModel
    {
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int CondominioId { get; set; }
        public Condominio Condominio { get; set; }
    }
}
