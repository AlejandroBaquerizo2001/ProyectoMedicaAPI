using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioInventario
    {
        Task<List<Inventario>> ObtenerTodos();
        Task<Inventario?> ObtenerPorID(int id);
        Task<int> Crear(Inventario inventario);

        Task<int> ModificarInventario(Inventario inventario);
        Task EliminarInventario(int id);
    }
}
