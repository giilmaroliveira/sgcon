using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository.Contracts
{
    public interface IBaseDataService<T> where T : class
    {
        T Get(int id);
        T Post(T entity);
        T Update(T entity);
        void Delete(int id);
        IQueryable<T> GetAll(Dictionary<string, object> filters = null);
        DbSet<T> Entities { get; }
        bool Exists(int id);
    }
}
