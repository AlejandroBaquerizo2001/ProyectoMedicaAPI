using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioUsuario
    {
        Task<List<Usuario>> ObtenerTodos();
        Task<Usuario?> ObtenerPorID(int id);

        Task<int> Crear(Usuario usuario);
        Task<int> ModificarUsuario(Usuario usuario);
        Task EliminarUsuario(int id);
    }
}
