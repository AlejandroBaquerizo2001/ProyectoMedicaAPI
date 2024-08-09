using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public class RepositorioCita : IRepositorioCita
    {
        private readonly AplicationDbContext context;
        public RepositorioCita(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Cita cita)
        {
            context.Citas.Add(cita);
            await context.SaveChangesAsync();

            return cita.Id;
        }

        public async Task<Cita?> ObtenerPorId(int id)
        {
            return context.Citas.Where(cita => cita.Id == id)
                 .ToList()[0];

        }

        public async Task EliminarCita(int id)
        {
            Cita cita = await context.Citas.FindAsync(id);
            context.Citas.Remove(cita);
            context.SaveChanges();
        }

        public async Task<int> ModificarCita(Cita cita)
        {
            Cita objCita = await context.Citas.FindAsync(cita.Id);
            objCita.Usuario = cita.Usuario;
            objCita.Doctor = cita.Doctor;
            objCita.Especialidad = cita.Especialidad;
            objCita.FechaCita = cita.FechaCita;
            await context.SaveChangesAsync();
            return objCita.Id;
        }

        public async Task<List<Cita>> ObtenerTodos()
        {
            return await context.Citas.ToListAsync();
        }
    }
}
