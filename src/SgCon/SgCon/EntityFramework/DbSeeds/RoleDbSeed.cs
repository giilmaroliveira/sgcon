using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class RoleDbSeed : DbSeedBase
    {
        public RoleDbSeed(SgConContext context) : base(context)
        {
            if (!context.Roles.Any())
            {
                List<Role> roles = new List<Role>();

                Role roleAdministrator = new Role
                {
                    Id = 1,
                    Description = "Administrador",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                roles.Add(roleAdministrator);

                Role roleEmployee = new Role
                {
                    Id = 2,
                    Description = "Funcionário",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                roles.Add(roleEmployee);

                Role roleResident = new Role
                {
                    Id = 3,
                    Description = "Morador",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                roles.Add(roleResident);

                context.AddRange(roles);
                context.SaveChanges();
            }
        }
    }
}
