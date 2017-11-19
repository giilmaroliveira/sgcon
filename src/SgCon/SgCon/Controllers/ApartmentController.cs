using SgConAPI.Controllers.Base;
using SgConAPI.Controllers.Contracts;
using SgConAPI.Models;
using Microsoft.AspNetCore.Mvc;
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
            _apartmentRepository = apartmentRepository;
            _apartmentBusinessService = apartmentBusinessService;
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
            if (apartment == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(apartment);

            if (ModelState.IsValid)
            {
                var result = _apartmentBusinessService.CreateApartment(apartment);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, "Dados obrigários não preenchidos, verifique e tente novamente");
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(Apartment), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] Apartment apartment, [FromRoute] int id)
        {
            if (apartment == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(apartment);

            if (ModelState.IsValid)
            {
                var result = _apartmentBusinessService.UpdateApartment(apartment, id);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, "Dados obrigários não preenchidos, verifique e tente novamente");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(Apartment), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == 0) { return StatusCode(400, "Dados não encontrados"); }

            var result = _apartmentBusinessService.GetById(id);

            if (result != null)
                _apartmentBusinessService.DeleteApartment(id);

            return Ok();
        }
    }
}
