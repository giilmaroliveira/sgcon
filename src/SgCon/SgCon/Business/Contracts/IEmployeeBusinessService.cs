using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Business.Contracts
{
    public interface IEmployeeBusinessService : IBaseBusinessService<IEmployeeRepository, Employee>
    {
        Employee GetById(int id);
        Employee CreateEmployee(Employee model);
        Employee UpdateEmployee(Employee model, int id);
        void DeleteEmployee(int id);
        IQueryable<Employee> GetAll(string filters);
    }
}
