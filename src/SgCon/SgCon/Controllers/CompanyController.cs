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
    [Route("api/company")]
    public class CompanyController : BaseController, IController<Company>
    {
        private readonly ICompanyBusinessService _companyBusinessService;
        public CompanyController(ICompanyBusinessService companyBusinessService)
        {
            _companyBusinessService = companyBusinessService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _companyBusinessService.GetById(id);

            if (result == null)
                return StatusCode(400, "Nenhum funcionário encontrado");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromHeader] string filtersJson = null)
        {
            var itens = _companyBusinessService.GetAll(filtersJson);

            if (itens == null)
                return StatusCode(400, "Nenhum funcionário encontrado");

            return Ok(itens);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Company company)
        {
            if (company == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(company);

            if (ModelState.IsValid)
            {
                var result = _companyBusinessService.CreateCompany(company);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Company company, [FromRoute] int id)
        {
            if (company == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(company);

            if (ModelState.IsValid)
            {
                var result = _companyBusinessService.UpdateCompany(company, id);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Company), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == 0) { return StatusCode(400, "Dados não encontrados"); }

            var result = _companyBusinessService.GetById(id);

            if (result != null)
                _companyBusinessService.DeleteCompany(id);

            return Ok();
        }
    }
}
