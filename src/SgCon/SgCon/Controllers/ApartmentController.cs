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
    [Route("api/apartment")]
    public class ApartmentController : BaseController, IController<Apartment>
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IApartmentBusinessService _apartmentBusinessService;
        public ApartmentController(
            IApartmentRepository apartmentRepository,
            IApartmentBusinessService apartmentBusinessService)
        {
            _apartmentBusinessService = apartmentBusinessService;
            _apartmentRepository = apartmentRepository;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Apartment), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _apartmentBusinessService.GetById(id);

            if (result == null)
                return BadRequest("Nenhum apartamento encontrado");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(Apartment), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromRoute] string filtersJson = null)
        {
            var result = _apartmentBusinessService.GetAll(filtersJson);

            if (result == null)
                return BadRequest("Nenhum apartamento encontrado");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Apartment), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] Apartment apartment)
        {
            var result = _apartmentBusinessService.CreateApartment(apartment);

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Apartment), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Apartment apartment, [FromRoute] int id)
        {
            var result = _apartmentBusinessService.UpdateApartment(apartment, id);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Apartment), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            var result = _apartmentBusinessService.GetById(id);

            if (result != null)
                _apartmentBusinessService.DeleteApartment(id);

            return Ok();
        }

    }
}
