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
    [Route("api/tower")]
    public class TowerController : BaseController, IController<Tower>
    {
        private readonly ITowerRepository _towerRepository;
        private readonly ITowerBusinessService _towerBusinessService;
        public TowerController(
            ITowerRepository towerRepository,
            ITowerBusinessService towerBusinessService)
        {
            _towerBusinessService = towerBusinessService;
            _towerRepository = towerRepository;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _towerBusinessService.GetById(id);

            if (result == null)
                return BadRequest("Nenhuma torre encontrado");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromRoute] string filtersJson = null)
        {
            var result = _towerBusinessService.GetAll(filtersJson);

            if (result == null)
                return BadRequest("Nenhuma torre encontrado");

            return Ok(result);
        }

        [HttpGet]
        [Route("condominium/{id}")]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetByCondominiumId([FromRoute] int id)
        {
            var result = _towerBusinessService.GetByCondominiumId(id);

            if (result == null)
                return BadRequest("Nenhuma torre encontrado");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Tower tower)
        {
            var result = _towerBusinessService.CreateTower(tower);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Tower tower, [FromRoute] int id)
        {
            var result = _towerBusinessService.UpdateTower(tower, id);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _towerBusinessService.GetById(id);

            if (result != null)
                _towerBusinessService.DeleteTower(id);

            return Ok();
        }

    }
}
