using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public interface IRepositorioDoctor
    {
        Task<List<Doctor>> ObtenerTodos();
        Task<Doctor?> ObtenerPorID(int id);

        Task<int> Crear(Doctor doctores);
        Task<int> ModificarDoctor(Doctor doctores);
        Task EliminarDoctor(int id);
    }
}
