using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class ProfileDbSeed : DbSeedBase
    {
        public ProfileDbSeed(SgConContext context) : base(context)
        {
            if (!context.Profiles.Any())
            {
                List<Profile> profiles = new List<Profile>();

                Profile profileAdmin = new Profile
                {
                    Name = "Administrador",
                    Description = "Administrador",
                    Role = context.Roles.Find(1)
                };
                profiles.Add(profileAdmin);

                Profile profileEmployee = new Profile
                {
                    Name = "Funcionário",
                    Description = "Funcionário",
                    Role = context.Roles.Find(2)
                };
                profiles.Add(profileEmployee);

                Profile profileResident = new Profile
                {
                    Name = "Morador",
                    Description = "Morador",
                    Role = context.Roles.Find(3)
                };
                profiles.Add(profileResident);
            }
        }
    }
}
