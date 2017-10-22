using SgCon.API.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SgCon.API.Models
{
    public class Predio : BaseModel
    {
        //[Key]
        //public int IdPredio { get; set; }
        public string Descricao { get; set; }

        //FK
        public int IdCondominio { get; set; }
        public Condominio Condominio { get; set; }
    }
}