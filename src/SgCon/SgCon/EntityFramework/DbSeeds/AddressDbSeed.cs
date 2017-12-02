using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class AddressDbSeed : DbSeedBase
    {
        public AddressDbSeed(SgConContext context) : base(context)
        {
            if (!context.Addresses.Any())
            {
                List<Address> listAddresses = new List<Address>();

                Address addressCondominium = new Address
                {
                    Id = 1,
                    AddressType = context.AddressesTypes.Find(1),
                    CEP = "05140060",
                    Street = "Rua Genésio Arruda",
                    Number = 500,
                    Neighborhood = "Chácara Inglesa",
                    City = "São Paulo",
                    UF = "SP",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                listAddresses.Add(addressCondominium);

                Address addressCondominiumTwo = new Address
                {
                    Id = 2,
                    AddressType = context.AddressesTypes.Find(1),
                    CEP = "05140060",
                    Street = "Rua Genésio Arruda",
                    Number = 900,
                    Neighborhood = "Chácara Inglesa",
                    City = "São Paulo",
                    UF = "SP",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                listAddresses.Add(addressCondominiumTwo);

                Address addressCompany = new Address
                {
                    Id = 3,
                    AddressType = context.AddressesTypes.Find(2),
                    CEP = "05440000",
                    Street = "Rua Paulistânia",
                    Number = 500,
                    Neighborhood = "Sumarezinho",
                    City = "São Paulo",
                    UF = "SP",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                listAddresses.Add(addressCompany);

                Address addressCompanyTwo = new Address
                {
                    Id = 4,
                    AddressType = context.AddressesTypes.Find(2),
                    CEP = "05440000",
                    Street = "Rua Paulistânia",
                    Number = 700,
                    Neighborhood = "Sumarezinho",
                    City = "São Paulo",
                    UF = "SP",
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                listAddresses.Add(addressCompanyTwo);


                context.AddRange(listAddresses);
                context.SaveChanges();
            }
        }
    }
}
