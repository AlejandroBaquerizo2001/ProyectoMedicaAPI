using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Entidades
{
    public class Cita
    {
        public int Id { get; set; }

        public string Usuario { get; set; } = null!;

        public string Doctor { get; set; } = null!;

        public string Especialidad { get; set; } = null!;

        public DateOnly FechaCita { get; set; }
    }
}
