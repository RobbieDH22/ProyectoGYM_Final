using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoGYM.DOMAIN.Core.DTOs
{
    public class ProductosDTO
    {
        public int CodigoProd { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
        public double Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; } = null!;
    }
    public class ProductosEstadoDTO
    {
        public int CodigoProd { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = null!;


    }
    public class ProductosNombreDTO
    {
        public int CodigoProd { get; set; }
        public string Nombre { get; set; } = null!;


    }
    public class ProductosPostDTO
    {
        public int CodigoProd { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Stock { get; set; }
        public double Precio { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; } = null!;
    }

}
