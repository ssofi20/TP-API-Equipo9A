using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogoProductos.API.DTOs
{
    public class ArticuloDto
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public string Descripcio { get; set; }
        public int IdMarca { get; set; }
        public int IdCateogria { get; set; }
        public decimal Precio { get; set; }
    }
}