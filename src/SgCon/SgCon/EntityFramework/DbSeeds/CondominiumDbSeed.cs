using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class CondominiumDbSeed : DbSeedBase
    {
        public CondominiumDbSeed(SgConContext context) :base(context)
        {
            if (!context.Condominiums.Any())
            {
                List<Condominium> condominiuns = new List<Condominium>();

                Condominium condominiumOne = new Condominium
                {
                    Id = 1,
                    Name = "Condomínio 1",
                    Cnpj = "85351161000182",
                    Email = "condominio1@sgcon.com",
                    DDDComercialPhone = "11",
                    ComercialPhone = "12345678",
                    TowerNumber = 2,
                    Address = context.Addresses.Find(1),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                condominiuns.Add(condominiumOne);

                Condominium condominiumTwo = new Condominium
                {
                    Id = 2,
                    Name = "Condomínio 2",
                    Cnpj = "85351161000182",
                    Email = "condominio1@sgcon.com",
                    DDDComercialPhone = "11",
                    ComercialPhone = "12345678",
                    TowerNumber = 2,
                    Address = context.Addresses.Find(2),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                condominiuns.Add(condominiumTwo);

                context.Condominiums.AddRange(condominiuns);
                context.SaveChanges();
            }
        }
    }
}
