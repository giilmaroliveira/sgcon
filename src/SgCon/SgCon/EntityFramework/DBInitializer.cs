using SgConAPI.EntityFramework.DbSeeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework
{
    public static class DbInitializer
    {
        public static void Initialize(SgConContext context)
        {
            context.Database.EnsureCreated();

            CondominiumDbSeed condominiumDbSeed = new CondominiumDbSeed(context);

            TowerDbSeed towerDbSeed = new TowerDbSeed(context);

            ApartmentDbSeed apartmentDbSeed = new ApartmentDbSeed(context);

            RoleDbSeed roleDbSeed = new RoleDbSeed(context);

            ProfileDbSeed profileDbSeed = new ProfileDbSeed(context);

            EmployeeDbSeed employeeDbSeed = new EmployeeDbSeed(context);

            ResidentDbSeed residentDbSeed = new ResidentDbSeed(context);

            CompanyDbSeed companyDbSeed = new CompanyDbSeed(context);

            CommonAreaDbSeed commonAreaDbSeed = new CommonAreaDbSeed(context);
        }
    }
}
