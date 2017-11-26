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
    [Route("api/commonarea")]
    public class CommonAreaController : BaseController, IController<CommonArea>
    {
        private readonly ICommonAreaBusinessService _commonAreaBusinessService;
        private readonly ICommonAreaScheduleBusinessService _scheduleBusinessService;
        public CommonAreaController(
            ICommonAreaBusinessService commonAreaBusinessService,
            ICommonAreaScheduleBusinessService commonAreaScheduleBusinessService)
        {
            _commonAreaBusinessService = commonAreaBusinessService;
            _scheduleBusinessService = commonAreaScheduleBusinessService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(CommonArea), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Get([FromRoute] int id)
        {
            var result = _commonAreaBusinessService.GetById(id);

            if (result == null)
                return StatusCode(400, "Nenhuma área de lazer encontrada");

            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(CommonArea), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAll([FromRoute] string filtersJson = null)
        {
            var result = _commonAreaBusinessService.GetAll(filtersJson);

            if (result == null)
                return StatusCode(400, "Nenhuma área de lazer encontrada");

            return Ok(result);
        }

        [HttpGet]
        [Route("condominium/{id}")]
        [ProducesResponseType(typeof(CommonArea), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetByCondominiumId([FromRoute] int id)
        {
            var result = _commonAreaBusinessService.GetByCondominiumId(id);

            if (result == null)
                return StatusCode(400, "Dados não encontrados");

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommonArea), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Post([FromBody, Required] CommonArea commonArea)
        {
            if (commonArea == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(commonArea);

            if (ModelState.IsValid)
            {
                var result = _commonAreaBusinessService.CreateCommonArea(commonArea);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(typeof(CommonArea), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Put([FromBody] CommonArea commonArea, [FromRoute] int id)
        {
            if (commonArea == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(commonArea);

            if (ModelState.IsValid)
            {
                var result = _commonAreaBusinessService.UpdateCommonArea(commonArea, id);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(CommonArea), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult Delete([FromRoute] int id)
        {
            if (id == 0) { return StatusCode(400, "Dados não encontrados"); }

            var result = _commonAreaBusinessService.GetById(id);

            if (result != null)
                _commonAreaBusinessService.DeleteCommonArea(id);

            return Ok();
        }

        [HttpGet]
        [Route("schedule/{id}")]
        [ProducesResponseType(typeof(CommonAreaSchedule), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetScheduleById([FromRoute] int id)
        {
            var result = _scheduleBusinessService.GetById(id);

            if (result == null)
                return StatusCode(400, "Nenhuma agendamento encontrado");

            return Ok(result);
        }

        [HttpGet]
        [Route("schedule")]
        [ProducesResponseType(typeof(CommonAreaSchedule), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult GetAllSchedules([FromRoute] string filtersJson = null)
        {
            var result = _scheduleBusinessService.GetAll(filtersJson);

            if (result == null)
                return StatusCode(400, "Nenhum agendamento encontrado");

            return Ok(result);
        }

        [HttpPost]
        [Route("schedule")]
        [ProducesResponseType(typeof(CommonAreaSchedule), 200)]
        [ProducesResponseType(typeof(string), 420)]
        [AllowAnonymous]
        public IActionResult PostSchedule([FromBody, Required] CommonAreaSchedule schedule)
        {
            if (schedule == null) { return StatusCode(400, "Dados não encontrados"); }

            ModelState.Clear();

            TryValidateModel(schedule);

            if (ModelState.IsValid)
            {
                var result = _scheduleBusinessService.CreateSchedule(schedule);

                return Ok(result);
            }
            else
            {
                return StatusCode(400, ModelState);
            }
        }
    }
}
