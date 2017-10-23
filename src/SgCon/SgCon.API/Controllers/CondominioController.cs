using SgCon.API.Models;
using SgCon.API.Repository.Contracts;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SgCon.API.Controllers
{
    [RoutePrefix("condominio")]
    public class CondominioController : Controller
    {
        private readonly ICondominioRepository _condominioRepository;
        public CondominioController(ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }

        [HttpGet]
        public List<Condominio> Index()
        {
            var condominios = _condominioRepository.GetAll();

            return condominios;
        }
    }
}