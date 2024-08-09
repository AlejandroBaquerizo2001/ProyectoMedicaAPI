using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioHistorial
    {
        Task<List<Historial>> ObtenerTodos();
        Task<Historial?> ObtenerPorID(int id);
        Task<int> Crear(Historial historial);

        Task<int> ModificarHistorial(Historial historial);
        Task EliminarHistorial(int id);
    }
}
