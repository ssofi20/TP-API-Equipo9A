using CatalogoProductos.API.DTOs;
using CatalogoProductos.Dominio;
using CatalogoProductos.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;

namespace CatalogoProductos.API.Controllers
{
    public class ArticuloController : ApiController
    {
        // GET: api/Articulo (Listar Articulos)
        public IEnumerable<Articulo> Get()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            return negocio.listar();
        }

        // GET: api/Articulo/5 (Buscar Articulo por Id)
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Articulo (Dar de alta Articulo)
        public void Post([FromBody]ArticuloDto art)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo nuevo = new Articulo();

            if (!string.IsNullOrEmpty(art.Codigo))
            {
                nuevo.Codigo = art.Codigo;
            }else
            {
                throw new Exception("Debe ingresar un código.");
            }

            if (!string.IsNullOrEmpty(art.Nombre))
            {
                nuevo.Nombre = art.Nombre;
            }else
            {
                throw new Exception("Debe ingresar un nombre.");
            }

            if (!string.IsNullOrEmpty(art.Descripcion))
            {
                nuevo.Descripcion = art.Descripcion;
            }else
            {
                throw new Exception("Debe ingresar una descripcion.");
            }

            if (art.Precio > 0)
            {
                nuevo.Precio = art.Precio;
            }else
            {
                throw new Exception("Debe ingresar un precio.");
            }

            if (art.IdMarca > 0)
            {
                nuevo.Marca = new Marca { Id = art.IdMarca };
            }else
            {
                throw new Exception("Debe ingresar una marca.");
            }

            if (art.IdCategoria > 0)
            {
                nuevo.Categoria = new Categoria { Id = art.IdCategoria };
            } else
            {
                throw new Exception("Debe ingresar una categoria.");
            }

            negocio.agregar(nuevo);
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
            if(!string.IsNullOrEmpty(articulo.Descripcion))
                articuloModificar.Descripcion = articulo.Descripcion;
            articuloModificar.Marca = new Marca();
            if(articulo.IdMarca > 0 && articulo.IdMarca != articuloModificar.Marca.Id)
                articuloModificar.Marca.Id = articulo.IdMarca;
            articuloModificar.Categoria = new Categoria();
            if(articulo.IdCategoria > 0 && articulo.IdCategoria != articuloModificar.Categoria.Id)
                articuloModificar.Categoria.Id = articulo.IdCategoria;
            if(articulo.Precio > 0 && articulo.Precio != articuloModificar.Precio)
                articuloModificar.Precio = articulo.Precio;

            //Llamo al metodo modificar de la capa negocio
            negocio.modificar(articuloModificar);
        }

        // DELETE: api/Articulo/5 (Eliminar Articulo)
        public void Delete(int id)
        {
        }
    }
}
