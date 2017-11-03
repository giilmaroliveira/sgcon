﻿using SgCon.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SgCon.API.Repository.Contracts
{
    public interface ICondominioRepository
    {
        IEnumerable<Condominio> GetAll();
        Condominio Get(int id);
        Condominio Add(Condominio item);
        void Remove(int id);
        bool Update(Condominio item);
    }
}