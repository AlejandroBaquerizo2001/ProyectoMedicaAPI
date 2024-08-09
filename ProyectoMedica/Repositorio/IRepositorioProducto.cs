using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioProducto
    {
        Task<List<Producto>> ObtenerTodos();
        Task<Producto?> ObtenerPorID(int id);

        Task<int> Crear(Producto productos);
        Task<int> ModificarProducto(Producto productos);
        Task EliminarProducto(int id);
    }
}
