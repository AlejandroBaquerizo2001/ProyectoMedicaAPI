using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Entidades
{
    public class Servicios
    {
        public  int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Area { get; set; } = null!;

        public string Oferta { get; set; } = null!;

        public int Valor {  get; set; }
    }
}
