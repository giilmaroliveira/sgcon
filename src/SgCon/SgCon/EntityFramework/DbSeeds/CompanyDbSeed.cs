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
                    CEP = "05140060",
                    Street = "Rua Genésio Arruda",
                    Number = 500,
                    Neighborhood = "Chácara Inglesa",
                    City = "São Paulo",
                    UF = "SP",
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
                    CEP = "05140060",
                    Street = "Rua Genésio Arruda",
                    Number = 900,
                    Neighborhood = "Chácara Inglesa",
                    City = "São Paulo",
                    UF = "SP",
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
