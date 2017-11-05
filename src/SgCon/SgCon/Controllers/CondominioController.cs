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

namespace SgConAPI.Controllers
{
    [Route("api/condominio")]
    public class CondominioController : BaseController, IController<Condominio>
    {
        private readonly ICondominioRepository _condominioRepository;
        public CondominioController(ICondominioRepository repository)
        {
            _condominioRepository = repository;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominio), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _condominioRepository.Get(id);

            return Ok(result);
                  
        }

        [HttpPost]
        [ProducesResponseType(typeof(Condominio), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Condominio condominio)
        {
            var result = _condominioRepository.Post(condominio);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Condominio), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Condominio condominio, [FromRoute] int id)
        {
            var result = _condominioRepository.Update(condominio);

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
                _condominioRepository.Delete(id);

            return Ok();
        }
    }
}
