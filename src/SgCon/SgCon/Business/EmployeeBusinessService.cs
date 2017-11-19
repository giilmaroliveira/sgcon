using SgConAPI.Business.Base;
using SgConAPI.Business.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business
{
    internal class EmployeeBusinessService : BaseBusinessService<IEmployeeRepository, Employee>, IEmployeeBusinessService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeBusinessService(IEmployeeRepository repository) : base(repository)
        {
            _employeeRepository = repository;
        }
    }
}
