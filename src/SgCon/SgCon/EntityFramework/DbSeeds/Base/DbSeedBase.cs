using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds.Base
{
    public abstract class DbSeedBase
    {
        public SgConContext Context;
        public DbSeedBase(SgConContext context)
        {
            Context = context;
        }
    }
}
