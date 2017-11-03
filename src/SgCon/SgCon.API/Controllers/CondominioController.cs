using SgCon.API.Models;
using SgCon.API.Repository;
using SgCon.API.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SgCon.API.Controllers
{
    [System.Web.Http.Route("api/condominio")]
    public class CondominioController : Controller
    {
        //static readonly ICondominioRepository _condominioRepository = new CondominioRepository();
        private readonly ICondominioRepository _condominioRepository;

        public CondominioController(
            ICondominioRepository condominioRepository)
        {
            _condominioRepository = condominioRepository;
        }
        public IEnumerable<Condominio> GetAllCondominios()
        {
            return _condominioRepository.GetAll();
        }
        public Condominio GetCondominio(int id)
        {
            Condominio item = _condominioRepository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public IEnumerable<Condominio> GetCondominiosPorCategoria(string categoria)
        {
            //return _condominioRepository.GetAll().Where(
            //    p => string.Equals(p.Categoria, categoria, StringComparison.OrdinalIgnoreCase));
            throw new NotImplementedException();
        }
        public HttpResponseMessage PostCondominio(Condominio item)
        {
            //item = _condominioRepository.Add(item);
            //var response = Request.CreateResponse<Condominio>(HttpStatusCode.Created, item);
            //string uri = Url.Link("DefaultApi", new { id = item.Id });
            //response.Headers.Location = new Uri(uri);
            var response = new HttpResponseMessage();
            return response;
        }
        public void PutCondominio(int id, Condominio produto)
        {
            produto.Id = id;
            if (!_condominioRepository.Update(produto))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteCondominio(int id)
        {
            Condominio item = _condominioRepository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _condominioRepository.Remove(id);
        }
    }
}
