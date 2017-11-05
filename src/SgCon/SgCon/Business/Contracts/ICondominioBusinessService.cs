using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business.Contracts
{
    public interface ICondominioBusinessService : IBaseBusinessService<ICondominioRepository, Condominio>
    {
    }
}
