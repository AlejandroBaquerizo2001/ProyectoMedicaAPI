using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioAdquirido
    {
        Task<List<Adquirido>> ObtenerTodos();
        Task<Adquirido?> ObtenerPorID(int id);
        Task<int> Crear(Adquirido adquirido);

        Task<int> ModificarAdquirido(Adquirido adquirido);
        Task EliminarAdquirido(int id);
    }
}
