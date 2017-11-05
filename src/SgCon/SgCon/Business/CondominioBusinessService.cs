using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business
{
    internal class CondominioBusinessService : BaseBusinessService<ICondominioRepository, Condominio>, ICondominioBusinessService
    {
        public CondominioBusinessService(ICondominioRepository repository) : base(repository)
        {
        }
    }
}
