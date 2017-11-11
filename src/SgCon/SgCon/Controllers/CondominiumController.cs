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
    [Route("api/condominium")]
    public class CondominiumController : BaseController
    {
        private readonly ICondominiumRepository _condominiumRepository;
        private readonly ICondominiumBusinessService _condominiumBusinessService;
        public CondominiumController(
            ICondominiumRepository repository, 
            ICondominiumBusinessService condominiumBusinessService)
        {
            _condominiumRepository = repository;
            _condominiumBusinessService = condominiumBusinessService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _condominiumBusinessService.GetById(id);

            if (result == null)
                return BadRequest("Nenhum condomínio encontrado");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromHeader] string filtersJson = null)
        {
            var itens = _condominiumBusinessService.GetAll(filtersJson);

            return Ok(itens);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Condominium condominium)
        {
            var result = _condominiumBusinessService.CreateCondominium(condominium);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Condominium condominium, [FromRoute] int id)
        {
            var result = _condominiumBusinessService.UpdateCondominium(condominium, id);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _condominiumBusinessService.GetById(id);

            if (result != null)
                _condominiumBusinessService.DeleteCondominium(id);

            return Ok();
        }
    }
}
