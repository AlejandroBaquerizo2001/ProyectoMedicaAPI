using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public class RepositorioDoctor : IRepositorioDoctor
    {
        private readonly AplicationDbContext context;
        public RepositorioDoctor(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Doctor doctores)
        {
            context.Doctores.Add(doctores);
            await context.SaveChangesAsync();

            return doctores.Id;
        }

        public async Task<Doctor?> ObtenerPorID(int id)
        {
            return context.Doctores.Where(x => x.Id == id)
                .ToList()[0];
        }

        public async Task EliminarDoctor(int id)
        {
            Doctor doctores = await context.Doctores.FindAsync(id);
            context.Doctores.Remove(doctores);
            context.SaveChanges();
        }

        public async Task<int> ModificarDoctor(Doctor doctores)
        {
            Doctor objDoctores = await context.Doctores.FindAsync(doctores.Id);
            objDoctores.Nombre = doctores.Nombre;
            objDoctores.Especialidad = doctores.Especialidad;
            objDoctores.Area = doctores.Area;
            objDoctores.FechaIngreso = doctores.FechaIngreso;
            await context.SaveChangesAsync();
            return objDoctores.Id;
        }

        public async Task<List<Doctor>> ObtenerTodos()
        {
            return await context.Doctores.ToListAsync();
        }
    }
}
