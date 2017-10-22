using SgCon.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SgCon.API.Models
{
    public class Condominio : BaseModel
    {
        public string Descricao { get; set; }
        public string Cnpj { get; set; }
        public int NumPredios { get; set; }

        public ICollection<Predio> Predios { get; set; }
    }
}