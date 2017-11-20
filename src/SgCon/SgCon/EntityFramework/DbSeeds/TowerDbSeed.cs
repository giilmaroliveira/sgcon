using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class TowerDbSeed : DbSeedBase
    {
        public TowerDbSeed(SgConContext context) : base(context)
        {
            if (!context.Towers.Any())
            {
                List<Tower> towers = new List<Tower>();

                Tower towerOne = new Tower
                {
                    Id = 1,
                    Block = "Bloco A",
                    CondominiumId = 1,
                    FloorsNumber = 20,
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                towers.Add(towerOne);

                Tower towerTwo = new Tower
                {
                    Id = 2,
                    Block = "Bloco B",
                    CondominiumId = 1,
                    FloorsNumber = 20,
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                towers.Add(towerTwo);

                Tower towerThree = new Tower
                {
                    Id = 3,
                    Block = "Bloco A",
                    CondominiumId = 2,
                    FloorsNumber = 20,
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                towers.Add(towerThree);

                Tower towerFour = new Tower
                {
                    Id = 4,
                    Block = "Bloco B",
                    CondominiumId = 2,
                    FloorsNumber = 20,
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                towers.Add(towerFour);

                context.AddRange(towers);
                context.SaveChanges();
            }
        }
    }
}
