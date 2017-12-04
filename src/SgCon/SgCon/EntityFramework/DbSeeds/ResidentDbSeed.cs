using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class ResidentDbSeed : DbSeedBase
    {
        public ResidentDbSeed(SgConContext context) : base(context)
        {
            if (!context.Residents.Any())
            {
                List<Resident> residents = new List<Resident>();

                Resident residentOne = new Resident
                {
                    Id = 1,
                    Name = "Morador 1",
                    CPF = "59766767742",
                    Email = "morador1@email.com",
                    UserName = "morador1",
                    PassWord = "morador1",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now,
                    Profile = context.Profiles.Find(3),
                    DDDComercialPhone = "11",
                    ComercialPhone = "12345678"
                };
                residents.Add(residentOne);

                Resident residentTwo = new Resident
                {
                    Id = 2,
                    Name = "Morador 2",
                    CPF = "41362234478",
                    Email = "morador2@email.com",
                    UserName = "morador2",
                    PassWord = "morador2",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now,
                    Profile = context.Profiles.Find(3),
                    DDDComercialPhone = "11",
                    ComercialPhone = "12345678"
                };
                residents.Add(residentTwo);

                context.Residents.AddRange(residents);
                context.SaveChanges();
            }
        }
    }
}
