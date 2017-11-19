using Microsoft.AspNetCore.Mvc;
using SgConAPI.Controllers.Base;
using SgConAPI.Controllers.Contracts;
using SgConAPI.Models;
using System.ComponentModel.DataAnnotations;
using SgConAPI.Repository.Contracts;
using SgConAPI.Business.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace SgConAPI.Controllers
{
    [Route("api/employee")]
    public class EmployeeController : BaseController, IController<Employee>
    {

        public IActionResult Get([FromRoute] int id)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult GetAll([FromHeader] string filtersJson = null)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Post([FromBody, Required] Employee model)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Put([FromBody] Employee model, [FromRoute] int id)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult Delete([FromRoute] int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
