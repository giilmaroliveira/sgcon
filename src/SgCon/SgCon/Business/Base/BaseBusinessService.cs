using SgConAPI.Business.Contracts;
using SgConAPI.Models.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business.Base
{
    public class BaseBusinessService<T, TE> : IBaseBusinessService<T, TE> where T : IBaseDataService<TE> where TE : BaseModel
    {
        public readonly IBaseDataService<TE> Repository;
        public BaseBusinessService(IBaseDataService<TE> repository)
        {
            Repository = repository;
        }

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
