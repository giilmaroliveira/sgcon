using SgConAPI.Models.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SgConAPI.EntityFramework;

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
            this.context.Attach(entity);
            this.context.SaveChanges();

            return entity;
        }

        public virtual void Delete(int id)
        {
            var entity = this.Entities.Find(id);
            entity.ExcluidoEm = DateTime.Now;
            entity.Ativo = false;
            this.context.SaveChanges();
        }
    }
}
