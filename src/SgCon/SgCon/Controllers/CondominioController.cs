using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SgConAPI.Controllers.Base;
using SgConAPI.Controllers.Contracts;
using SgConAPI.Models;
using SgConAPI.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SgConAPI.Business.Contracts;

namespace SgConAPI.Controllers
{
    [Route("api/condominio")]
    public class CondominioController : BaseController, IController<Condominio>
    {
        private readonly ICondominioRepository _condominioRepository;
        private readonly ICondominioBusinessService _condominioBusinessService;
        public CondominioController(ICondominioRepository repository, ICondominioBusinessService condominioBusinessService)
        {
            _condominioRepository = repository;
            _condominioBusinessService = condominioBusinessService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominio), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _condominioBusinessService.GetById(id);

            if (result == null)
                return BadRequest("Nenhum condomínio encontrado");

            return Ok(result);   
        }

        [HttpPost]
        [ProducesResponseType(typeof(Condominio), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Condominio condominio)
        {
            var result = _condominioBusinessService.CreateCondominio(condominio);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominio), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Condominio condominio, [FromRoute] int id)
        {
            var result = _condominioBusinessService.UpdateCondominio(condominio, id);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominio), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _condominioRepository.Get(id);

            if (result != null)
                _condominioBusinessService.DeleteCondominio(id);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(Condominio), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromHeader] string filtersJson = null)
        {
            var itens = _condominioRepository.GetAll(issueFilterJson(filtersJson));

            return Ok(itens);
        }
    }
}
