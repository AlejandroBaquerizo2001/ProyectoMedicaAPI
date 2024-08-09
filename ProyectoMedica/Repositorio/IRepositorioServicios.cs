using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioServicios
    {
        Task<List<Servicios>> ObtenerTodos();
        Task<Servicios?> ObtenerPorID(int id);

        Task<int> Crear(Servicios servicios);
        Task<int> ModificarServicios(Servicios servicios);
        Task EliminarServicios(int id);
    }
}
