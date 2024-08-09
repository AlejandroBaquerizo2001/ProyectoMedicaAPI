using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public class RepositorioHistorial : IRepositorioHistorial
    {
        private readonly AplicationDbContext context;
        public RepositorioHistorial(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Historial historial)
        {
            context.Historiales.Add(historial);
            await context.SaveChangesAsync();

            return historial.Id;
        }

        public async Task<Historial?> ObtenerPorID(int id)
        {
            return context.Historiales.Where(historial => historial.Id == id)
                 .ToList()[0];

        }

        public async Task EliminarHistorial(int id)
        {
            Historial historial = await context.Historiales.FindAsync(id);
            context.Historiales.Remove(historial);
            context.SaveChanges();
        }

        public async Task<int> ModificarHistorial(Historial historial)
        {
            Historial objHistorial = await context.Historiales.FindAsync(historial.Id);
            objHistorial.Usuario = historial.Usuario;
            objHistorial.Doctor = historial.Doctor;
            objHistorial.Area = historial.Area;
            objHistorial.Estado = historial.Estado;
            await context.SaveChangesAsync();
            return objHistorial.Id;
        }

        public async Task<List<Historial>> ObtenerTodos()
        {
            return await context.Historiales.ToListAsync();
        }
    }
}
