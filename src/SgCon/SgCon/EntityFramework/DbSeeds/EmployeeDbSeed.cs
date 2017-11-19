using SgConAPI.EntityFramework.DbSeeds.Base;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.EntityFramework.DbSeeds
{
    public class EmployeeDbSeed : DbSeedBase
    {
        public EmployeeDbSeed(SgConContext context) : base(context)
        {
            if (!context.Employees.Any())
            {
                List<Employee> employees = new List<Employee>();

                Employee managerEmployee = new Employee
                {
                    Name = "Gerente",
                    CPF = "65702551346",
                    Email = "gerente@sgcon.com",
                    JobRole = "Gerente",
                    UserName = "admin",
                    PassWord = "admin",
                    Profile = context.Profiles.Find(1),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                employees.Add(managerEmployee);

                Employee managerAttendant = new Employee
                {
                    Name = "Atendente",
                    CPF = "65155881781",
                    Email = "atendente@sgcon.com",
                    JobRole = "Atendente",
                    UserName = "atendente",
                    PassWord = "atendente",
                    Profile = context.Profiles.Find(2),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                employees.Add(managerAttendant);

                Employee managerAttendantTwo = new Employee
                {
                    Name = "Atendente 2",
                    CPF = "25405493490",
                    Email = "atendente2@sgcon.com",
                    JobRole = "Atendente",
                    UserName = "atendente2",
                    PassWord = "atendente2",
                    Profile = context.Profiles.Find(2),
                    CreatedBy = "Sistema",
                    CreatedAt = DateTime.Now
                };
                employees.Add(managerAttendantTwo);

                context.AddRange(employees);
                context.SaveChanges();
            }
        }
    }
}
