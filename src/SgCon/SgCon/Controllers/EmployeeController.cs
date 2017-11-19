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
        private readonly IEmployeeBusinessService _employeeBusinessService;

        public EmployeeController(IEmployeeBusinessService employeeBusinessService)
        {
            _employeeBusinessService = employeeBusinessService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _employeeBusinessService.GetById(id);

            if (result == null)
                return StatusCode(400, "Nenhum funcionário encontrado");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromHeader] string filtersJson = null)
        {
            var itens = _employeeBusinessService.GetAll(filtersJson);

            if (itens == null)
                return StatusCode(400, "Nenhum funcionário encontrado");

            return Ok(itens);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Employee employee)
        {
            if (employee == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(employee);

            if (ModelState.IsValid)
            {
                var result = _employeeBusinessService.CreateEmployee(employee);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Employee employee, [FromRoute] int id)
        {
            if (employee == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(employee);

            if (ModelState.IsValid)
            {
                var result = _employeeBusinessService.UpdateEmployee(employee, id);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == 0) { return StatusCode(400, "Dados não encontrados"); }

            var result = _employeeBusinessService.GetById(id);

            if (result != null)
                _employeeBusinessService.DeleteEmployee(id);

            return Ok();
        }
    }
}
