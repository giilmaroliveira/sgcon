using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SgConAPI.Controllers.Base;
using SgConAPI.Controllers.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System.ComponentModel.DataAnnotations;
using SgConAPI.Business.Contracts;

namespace SgConAPI.Controllers
{
    [Route("api/resident")]
    public class ResidentController : BaseController
    {
        private IResidentBusinessService _residentBusinessService;
        public ResidentController(IResidentBusinessService residentBusinessService)
        {
            _residentBusinessService = residentBusinessService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Resident), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _residentBusinessService.GetById(id);

            if (result == null)
                return StatusCode(400, "Nenhum morador encontrado");

            return Ok(result);
        }

        /// <summary>
        /// Este método retorna todos registros da tabela condomínio
        /// </summary>
        /// <param name="filtersJson"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Resident), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromHeader] string filtersJson = null)
        {
            var itens = _residentBusinessService.GetAll(filtersJson);

            if (itens == null)
                return StatusCode(400, "Nenhum morador encontrado");

            return Ok(itens);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Resident), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Resident resident)
        {
            if (resident == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(resident);

            if (ModelState.IsValid)
            {
                var result = _residentBusinessService.CreateResident(resident);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Resident), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Resident resident, [FromRoute] int id)
        {
            if (resident == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(resident);

            if (ModelState.IsValid)
            {
                var result = _residentBusinessService.UpdateResident(resident, id);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }

        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Resident), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == 0) { return StatusCode(400, "Dados não encontrados"); }

            var result = _residentBusinessService.GetById(id);

            if (result != null)
                _residentBusinessService.DeleteResident(id);

            return Ok();
        }
    }
}
