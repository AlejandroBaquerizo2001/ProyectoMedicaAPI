using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioCita
    {
        Task<List<Cita>> ObtenerTodos();
        Task<Cita?> ObtenerPorId(int id);

        Task<int> Crear(Cita cita);

        Task<int> ModificarCita(Cita cita);
        Task EliminarCita(int id);
    }
}
