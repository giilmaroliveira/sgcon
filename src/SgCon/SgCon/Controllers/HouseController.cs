using SgConAPI.Controllers.Base;
using SgConAPI.Controllers.Contracts;
using SgConAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using SgConAPI.Repository.Contracts;
using SgConAPI.Business.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace SgConAPI.Controllers
{
    [Route("api/house")]
    public class HouseController : BaseController, IController<House>
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IHouseBusinessService _houseBusinessService;
        public HouseController(
            IHouseRepository houseRepository,
            IHouseBusinessService houseBusinessService)
        {
            _houseRepository = houseRepository;
            _houseBusinessService = houseBusinessService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(House), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _houseBusinessService.GetById(id);

            if (result == null)
                return BadRequest("Nenhuma casa encontrada");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(House), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromRoute] string filtersJson = null)
        {
            var result = _houseBusinessService.GetAll(filtersJson);

            if (result == null)
                return BadRequest("Nenhum casa encontrada");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(House), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] House House)
        {
            var result = _houseBusinessService.CreateHouse(House);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(House), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] House House, [FromRoute] int id)
        {
            var result = _houseBusinessService.UpdateHouse(House, id);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(House), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _houseBusinessService.GetById(id);

            if (result != null)
                _houseBusinessService.DeleteHouse(id);

            return Ok();
        }
    }
}
