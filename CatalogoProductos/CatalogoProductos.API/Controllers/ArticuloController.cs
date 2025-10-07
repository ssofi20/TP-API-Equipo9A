using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatalogoProductos.Dominio;
using CatalogoProductos.Negocio;

namespace CatalogoProductos.API.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo (Listar Articulos)
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Articulo/5 (Buscar Articulo por Id)
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Articulo (Dar de alta Articulo)
        public void Post([FromBody]Articulo value)
        {
        }

        // PUT: api/Articulo/5 (Modificar Articulo)
        public void Put(int id, [FromBody]Articulo value)
        {

        }

        // DELETE: api/Articulo/5 (Eliminar Articulo)
        public void Delete(int id)
        {
        }
    }
}
