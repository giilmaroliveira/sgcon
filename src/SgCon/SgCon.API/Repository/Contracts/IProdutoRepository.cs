using SgCon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SgCon.API.Repository.Contracts
{
    public interface IProdutoRepository
    {
        IEnumerable<Produto> GetAll();
        Produto Get(int id);
        Produto Add(Produto item);
        void Remove(int id);
        bool Update(Produto item);
    }
}