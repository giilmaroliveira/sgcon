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
                return StatusCode(400, "Nenhum condomínio encontrado");

            return Ok(result);
        }

        /// <summary>
        /// Este método retorna todos registros da tabela condomínio
        /// </summary>
        /// <param name="filtersJson"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromHeader] string filtersJson = null)
        {
            var itens = _condominiumBusinessService.GetAll(filtersJson);

            if (itens == null)
                return StatusCode(400, "Nenhum condomínio encontrado");

            return Ok(itens);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Condominium), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Condominium condominium)
        {
            if (condominium == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(condominium);

            if (ModelState.IsValid)
            {
                var result = _condominiumBusinessService.CreateCondominium(condominium);

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
        public IActionResult Put([FromBody] Condominium condominium, [FromRoute] int id)
        {
            if (condominium == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(condominium);

            if (ModelState.IsValid)
            {
                var result = _condominiumBusinessService.UpdateCondominium(condominium, id);

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

            var result = _condominiumBusinessService.GetById(id);

            if (result != null)
                _condominiumBusinessService.DeleteCondominium(id);

            return Ok();
        }
    }
}
