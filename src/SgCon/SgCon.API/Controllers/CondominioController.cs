using SgCon.API.Models;
using SgCon.API.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SgCon.API.Controllers
{
    [System.Web.Http.Route("api/condominio")]
    public class CondominioController : Controller
    {
        private readonly ICondominioRepository _condominioRepository;
        public CondominioController(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }

        public IEnumerable<Condominio> GetAll()
        {
            var condominios = _condominioRepository.GetAll();

            return condominios;
        }
    }
}