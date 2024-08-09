using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Entidades
{
    public class Producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string TipoProducto { get; set; } = null!;

        public int Cantidad { get; set; }

        public DateOnly FechaIngreso { get; set; }
    }
}
