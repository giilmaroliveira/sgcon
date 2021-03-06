﻿using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Repository.Contracts
{
    public interface IEmployeeRepository : IBaseDataService<Employee>
    {
        Employee GetEmployeeByUserName(string userName);
        Employee GetEmployeeByEmailOrUsername(ApplicationUser loginUser);
    }
}
