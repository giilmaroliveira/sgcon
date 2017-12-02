using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;

namespace SgConAPI.Repository
{
    internal class AddressRepository : BaseDataService<Address>, IAddressRepository
    {
        public AddressRepository(SgConContext context) : base(context)
        {

        }
    }
}
