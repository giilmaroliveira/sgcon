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

        public Employee GetById(int id)
        {
            return Repository.Get(id);
        }

        public Employee CreateEmployee(Employee model)
        { 
            var result = Repository.Post(model);

            return result;
        }

        public Employee UpdateEmployee(Employee model, int id)
        {
            var result = Repository.Update(model);

            return result;
        }

        public void DeleteEmployee(int id)
        {
            Repository.Delete(id);
        }

        public IQueryable<Employee> GetAll(string filters)
        {
            var result = Repository.GetAll(issueFilterJson(filters));

            return result;
        }

        public Employee GetEmployeeByEmailOrUsername(ApplicationUser loginUser)
        {
            return _employeeRepository.GetEmployeeByEmailOrUsername(loginUser);
        }
    }
}
