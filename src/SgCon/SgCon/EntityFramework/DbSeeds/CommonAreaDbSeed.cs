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

                CommonArea commonAreaOne = new CommonArea{
                    Id = 1,
                    CondominiumId = 1,
                    Name = "Área 1",
                    Description = "Área de lazer 1",
                    Capacity = 20,
                    IntervalTime = 60
                };
                commonArea.Add(commonAreaOne);

                CommonArea commonAreaTwo = new CommonArea
                {
                    Id = 2,
                    CondominiumId = 1,
                    Name = "Área 2",
                    Description = "Área de lazer 2",
                    Capacity = 20,
                    IntervalTime = 30
                };
                commonArea.Add(commonAreaTwo);

                context.AddRange(commonArea);
                context.SaveChanges();
            }
        }
    }
}
