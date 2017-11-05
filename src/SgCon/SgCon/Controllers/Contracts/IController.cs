using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Controllers.Contracts
{
    interface IController<T>
    {
        [HttpGet]
        IActionResult Get([FromRoute] int id);

        [HttpPost]
        IActionResult Post([FromBody, Required] T model);

        [HttpPut("{id}")]
        IActionResult Put([FromBody] T model, [FromRoute] int id);

        [HttpDelete("{id}")]
        IActionResult Delete([FromRoute] int id);

        [HttpGet]
        IActionResult GetAll([FromHeader] string filtersJson = null);
    }
}
