using SgConAPI.EntityFramework;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository
{
    internal class CompanyRepository : BaseDataService<Company>, ICompanyRepository
    {
        public CompanyRepository(SgConContext context) : base(context)
        {
            
        }
    }
}
