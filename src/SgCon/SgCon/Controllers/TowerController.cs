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
                return StatusCode(400, "Nenhuma torre encontrada");

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
                return StatusCode(400, "Nenhuma torre encontrada");

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
                return StatusCode(400, "Dados não encontrados");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Tower tower)
        {
            if (tower == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(tower);

            if (ModelState.IsValid)
            {
                var result = _towerBusinessService.CreateTower(tower);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, "Dados obrigários não preenchidos, verifique e tente novamente");
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Tower tower, [FromRoute] int id)
        { 
            if (tower == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(tower);

            if (ModelState.IsValid)
            {
                var result = _towerBusinessService.UpdateTower(tower, id);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, "Dados obrigários não preenchidos, verifique e tente novamente");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Tower), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == 0) { return StatusCode(400, "Dados não encontrados"); }

            var result = _towerBusinessService.GetById(id);

            if (result != null)
                _towerBusinessService.DeleteTower(id);

            return Ok();
        }

    }
}
