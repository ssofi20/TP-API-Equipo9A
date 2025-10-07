using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogoProductos.API.Controllers
{
    public class ProductoController : ApiController
    {
        // GET: api/Producto (Listar Productos)
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Producto/5 (Buscar Producto por Id)
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Producto (Dar de alta Producto)
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Producto/5 (Modificar Producto)
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Producto/5 (Eliminar Producto)
        public void Delete(int id)
        {
        }
    }
}
