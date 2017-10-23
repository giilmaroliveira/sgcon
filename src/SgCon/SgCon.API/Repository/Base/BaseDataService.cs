﻿using SgCon.API.EntityFramework;
using SgCon.API.Models.Base;
using SgCon.API.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SgCon.API.Repository.Base
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
    }
}