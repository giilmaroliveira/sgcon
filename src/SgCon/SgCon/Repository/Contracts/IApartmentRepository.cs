﻿using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository.Contracts
{
    public interface IApartmentRepository : IBaseDataService<Apartment>
    {
        IQueryable<Apartment> GetByTowerId(int id);
    }
}
