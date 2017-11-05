using SgConAPI.Models.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business.Contracts
{
    public interface IBaseBusinessService<T, TE>: IDisposable where T : IBaseDataService<TE> where TE : BaseModel
    {
    }
}
