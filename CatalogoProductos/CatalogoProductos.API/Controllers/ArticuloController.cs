using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CatalogoProductos.API.DTOs;
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
        public ArticuloNegocio Get(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            List<Articulo> lista = negocio.listar();

            return lista.Find(x => x.Id == id);
        }

        // POST: api/Articulo (Dar de alta Articulo)
        public void Post([FromBody]Articulo value)
        {
        }

        // PUT: api/Articulo/5 (Modificar Articulo)
        public void Put(int id, [FromBody]ArticuloDto articulo)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articuloModificar = new Articulo();

            List<Articulo> lista = negocio.listar();
            articuloModificar = lista.Find(a => a.Id == id);

            //Validaciones
            if (articuloModificar == null)
            {
                throw new Exception("No se encontro el articulo");
            }

            if (articulo == null)
            {
                throw new Exception("No se recibieron datos para modificar");
            }

            if(articulo.Nombre != articuloModificar.Nombre && lista.Exists(a => a.Nombre == articulo.Nombre))
            {
                throw new Exception("Ya existe un articulo con ese nombre");
            }

            if(articulo.Codigo != articuloModificar.Codigo && lista.Exists(a => a.Codigo == articulo.Codigo))
            {
                throw new Exception("Ya existe un articulo con ese codigo");
            }

            //Mapeo los datos del DTO al objeto Articulo y verifico cuales se modificaron
            articuloModificar.Id = id;
            if(!string.IsNullOrEmpty(articulo.Nombre))
                articuloModificar.Nombre = articulo.Nombre;
            if(!string.IsNullOrEmpty(articulo.Codigo))
                articuloModificar.Codigo = articulo.Codigo;
            if(!string.IsNullOrEmpty(articulo.Descripcio))
                articuloModificar.Descripcion = articulo.Descripcio;
            articuloModificar.Marca = new Marca();
            if(articulo.IdMarca > 0 && articulo.IdMarca != articuloModificar.Marca.Id)
                articuloModificar.Marca.Id = articulo.IdMarca;
            articuloModificar.Categoria = new Categoria();
            if(articulo.IdCateogria > 0 && articulo.IdCateogria != articuloModificar.Categoria.Id)
                articuloModificar.Categoria.Id = articulo.IdCateogria;
            if(articulo.Precio > 0 && articulo.Precio != articuloModificar.Precio)
                articuloModificar.Precio = articulo.Precio;

            //Llamo al metodo modificar de la capa negocio
            negocio.modificar(articuloModificar);
        }

        // DELETE: api/Articulo/5 (Eliminar Articulo)
        public void Delete(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            negocio.eliminar(id);

        }
    }
}
