using SgConAPI.Models.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SgConAPI.EntityFramework;
using SgConAPI.EntityFramework.QueryFilter;
using Newtonsoft.Json;

namespace SgConAPI.Repository.Base
{
    internal abstract class BaseDataService<T> : IBaseDataService<T> where T : BaseModel
    {
        internal readonly SgConContext context;
        private DbSet<T> entities;
        public BaseDataService(SgConContext context)
        {
            this.context = context;
        }

        public DbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }

        public virtual T Get(int id)
        {
            return (from b in this.Entities
                    where b.Id == id
                    select b).FirstOrDefault();
        }

        public virtual T Post(T entity)
        {
            this.Entities.Add(entity);
            this.context.SaveChanges();

            return entity;
        }

        public virtual T Update(T entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            //this.context.Attach(entity);
            this.context.SaveChanges();

            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = this.Entities.Find(id);
            entity.DeletedAt = DateTime.Now;
            entity.Active = false;
            this.context.SaveChanges();
        }

        public virtual IQueryable<T> GetAll(Dictionary<string, object> filters = null)
        {
            IQueryable<T> entities = this.Entities;
            if (filters != null)
            {
                var qFilter = new QueryFilterFactory<T>();
                foreach (var tuple in filters)
                {
                    entities = qFilter.QueryFieldContains(entities, tuple.Key, tuple.Value);
                }
            }
            return entities;
        }

        public virtual bool Exists (int id)
        {
            return this.Entities.Any(r => r.Id == id && r.DeletedAt == null);
        }

        //protected Dictionary<string, object> issueFilterJson(string filtersJson)
        //{
        //    Dictionary<string, object> filters = null;
        //    if (!string.IsNullOrEmpty(filtersJson))
        //    {
        //        filters = JsonConvert.DeserializeObject<Dictionary<string, object>>(filtersJson);
        //    }
        //    return filters;
        //}
    }
}
