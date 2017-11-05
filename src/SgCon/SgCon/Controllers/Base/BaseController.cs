using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SgConAPI.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected Dictionary<string, object> issueFilterJson(string filtersJson)
        {
            Dictionary<string, object> filters = null;
            if (!string.IsNullOrEmpty(filtersJson))
            {
                filters = JsonConvert.DeserializeObject<Dictionary<string, object>>(filtersJson);
            }
            return filters;
        }
    }
}
