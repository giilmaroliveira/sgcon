using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SgCon.API.Repository.Contracts
{
    public interface IBaseDataService<T> where T : class
    {
        DbSet<T> Entities { get; }
    }
}
