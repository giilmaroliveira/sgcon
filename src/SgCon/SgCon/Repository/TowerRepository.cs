using Microsoft.EntityFrameworkCore;
using SgConAPI.EntityFramework;
using SgConAPI.EntityFramework.QueryFilter;
using SgConAPI.Models;
using SgConAPI.Repository.Base;
using SgConAPI.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SgConAPI.Repository
{
    internal class TowerRepository : BaseDataService<Tower>, ITowerRepository
    {
        public TowerRepository(SgConContext context) : base(context)
        {
            
        }
    }
}
