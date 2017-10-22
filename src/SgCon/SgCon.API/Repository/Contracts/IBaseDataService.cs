using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SgCon.API.Repository.Contracts
{
    public interface IBaseDataService<T> where T : class
    {
        DbSet<T> Entities { get; }
    }
}