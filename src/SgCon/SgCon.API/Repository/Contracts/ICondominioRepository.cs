using SgCon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SgCon.API.Repository.Contracts
{
    public interface ICondominioRepository
    {
        List<Condominio> GetAll();
    }
}