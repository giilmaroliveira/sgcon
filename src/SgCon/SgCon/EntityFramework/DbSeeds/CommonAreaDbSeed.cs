using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SgConAPI.EntityFramework.DbSeeds
{
    public class CommonAreaDbSeed : DbSeedBase
    {
        public CommonAreaDbSeed(SgConContext context) : base(context)
        {
            if (!context.CommonAreas.Any())
            {
                List<CommonArea> commonArea = new List<CommonArea>();



                context.AddRange(commonArea);
                context.SaveChanges();
            }
        }
    }
}
