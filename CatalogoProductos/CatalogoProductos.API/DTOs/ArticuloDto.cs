using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CatalogoProductos.API.DTOs
{
    public class ArticuloDto
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }

        //Propiedad nueva para recibir las URLs de las imágene
        public List<string> UrlImagenes { get; set; } = new List<string>();
    }
}