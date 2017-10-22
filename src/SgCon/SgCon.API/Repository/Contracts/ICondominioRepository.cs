using SgCon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SgCon.API.Repository.Contracts
{
    public interface ICondominioRepository
    {
        List<Condominio> GetAll();
    }
}
