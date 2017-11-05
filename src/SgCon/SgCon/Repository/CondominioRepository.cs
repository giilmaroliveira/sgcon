﻿using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository
{
    internal class CondominioRepository : BaseDataService<Condominio>, ICondominioRepository
    {
        public CondominioRepository(SgConContext context) :base(context)
        {

        }
    }
}
