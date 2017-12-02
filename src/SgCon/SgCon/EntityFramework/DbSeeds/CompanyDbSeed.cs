using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class CompanyDbSeed : DbSeedBase
    {
        public CompanyDbSeed(SgConContext context) : base(context)
        {
            if (!context.Companies.Any())
            {
                List<Company> companies = new List<Company>();

                Company companyOne = new Company
                {
                    Id = 1,
                    Name = "Empresa 1",
                    Cnpj = "85351161000182",
                    Email = "empresa1@sgcon.com",
                    DDDComercialPhone = "11",
                    ComercialPhone = "12345678",
                    Address = context.Addresses.Find(3),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                companies.Add(companyOne);

                Company companyTwo = new Company
                {
                    Id = 2,
                    Name = "Empresa 2",
                    Cnpj = "85351161000182",
                    Email = "empresa2@sgcon.com",
                    DDDComercialPhone = "11",
                    ComercialPhone = "12345678",
                    Address = context.Addresses.Find(4),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                companies.Add(companyTwo);

                context.AddRange(companies);
                context.SaveChanges();
            }
        }
    }
}
