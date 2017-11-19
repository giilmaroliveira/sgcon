using SgConAPI.EntityFramework.DbSeeds.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class PoliciesDbSeed : DbSeedBase
    {
        public PoliciesDbSeed(SgConContext context) :base(context)
        {
            if (!context.Policies.Any())
            {

            }
        }
    }
}
