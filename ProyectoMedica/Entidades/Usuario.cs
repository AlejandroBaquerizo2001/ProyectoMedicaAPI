using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Identidad { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Clave { get; set; } = null!;
    }
}
