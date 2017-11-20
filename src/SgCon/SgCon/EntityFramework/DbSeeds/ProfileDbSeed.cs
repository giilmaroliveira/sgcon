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
                    Id = 1,
                    Name = "Administrador",
                    Description = "Administrador",
                    Role = context.Roles.Find(1),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                profiles.Add(profileAdmin);

                Profile profileEmployee = new Profile
                {
                    Id = 2,
                    Name = "Funcionário",
                    Description = "Funcionário",
                    Role = context.Roles.Find(2),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                profiles.Add(profileEmployee);

                Profile profileResidentContract = new Profile
                {
                    Id = 3,
                    Name = "Morador Contratante",
                    Description = "Morador Contratante",
                    Role = context.Roles.Find(3),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                profiles.Add(profileResidentContract);

                Profile profileResident = new Profile
                {
                    Id = 4,
                    Name = "Morador",
                    Description = "Morador",
                    Role = context.Roles.Find(3),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                profiles.Add(profileResident);

                context.AddRange(profiles);
                context.SaveChanges();
            }
        }
    }
}
