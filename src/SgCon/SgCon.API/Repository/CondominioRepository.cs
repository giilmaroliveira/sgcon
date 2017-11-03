using SgCon.API.EntityFramework;
using SgCon.API.Models;
using SgCon.API.Repository.Base;
using SgCon.API.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SgCon.API.Repository
{
    internal class CondominioRepository : BaseDataService<Condominio>, ICondominioRepository
    {
        //private readonly SgConContext _context;
        public CondominioRepository(SgConContext context) : base(context)
        {
            //_context = context;
        }

        public Condominio Add(Condominio item)
        {
            throw new NotImplementedException();
        }

        public Condominio Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Condominio> GetAll()
        {
            return Entities.Where(x => x.Active == true).ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Condominio item)
        {
            throw new NotImplementedException();
        }
    }
}