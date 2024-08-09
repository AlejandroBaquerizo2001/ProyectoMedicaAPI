using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Entidades
{
    public  class Inventario
    {
        public int Id { get; set; }

        public string Producto { get; set; } = null!;

        public string TipoProducto { get; set; } = null!;

        public int Cantidad { get; set; }

        public string Estado { get; set; } = null!;
    }
}
