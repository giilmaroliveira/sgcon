using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class AddressTypeDbSeed : DbSeedBase
    {
        public AddressTypeDbSeed(SgConContext context) : base(context)
        {
            if (!context.AddressesTypes.Any())
            {
                List<AddressType> listAddressesTypes = new List<AddressType>();

                AddressType addressTypeCondominium = new AddressType
                {
                    Id = 1,
                    Description = "Condomínio"
                };
                listAddressesTypes.Add(addressTypeCondominium);

                AddressType addressTypeCompany = new AddressType
                {
                    Id = 2,
                    Description = "Empresa"
                };
                listAddressesTypes.Add(addressTypeCompany);

                AddressType addressTypeEmployee = new AddressType
                {
                    Id = 3,
                    Description = "Funcionário"
                };
                listAddressesTypes.Add(addressTypeEmployee);

                context.AddRange(listAddressesTypes);
                context.SaveChanges();
            }
        }
    }
}
