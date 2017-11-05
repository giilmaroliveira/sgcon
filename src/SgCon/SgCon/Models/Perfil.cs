using SgConAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Models
{
    public class Perfil : BaseModel
    {
        public string Name { get; set; }

        public string Descricao { get; set; }

    }
}
