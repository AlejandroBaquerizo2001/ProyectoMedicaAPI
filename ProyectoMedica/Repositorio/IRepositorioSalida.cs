using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioSalida
    {
        Task<List<Salida>> ObtenerTodos();
        Task<Salida?> ObtenerPorID(int id);
        Task<int> Crear(Salida salida);

        Task<int> ModificarSalida(Salida salida);
        Task EliminarSalida(int id);
    }
}
