﻿using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository.Contracts
{
    public interface IResidentRepository : IBaseDataService<Resident>
    {
        Resident GetResidentByUserName(string userName);
        Resident GetResidentByEmailOrUsername(ApplicationUser loginUser);
    }
}
