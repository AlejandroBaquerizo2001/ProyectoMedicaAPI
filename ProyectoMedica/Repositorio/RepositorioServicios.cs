using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using ProyectoMedica.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public class RepositorioServicios : IRepositorioServicios
    {
        private readonly AplicationDbContext context;
        public RepositorioServicios(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Servicios servicios)
        {
            context.Servicios.Add(servicios);
            await context.SaveChangesAsync();

            return servicios.Id;
        }

        public async Task<Servicios?> ObtenerPorID(int id)
        {
            return context.Servicios.Where(x => x.Id == id)
            .ToList()[0];
        }

        public async Task<int> ModificarServicios(Servicios servicios)
        {
            Servicios objServicios = await context.Servicios.FindAsync(servicios.Id);
            objServicios.Nombre = servicios.Nombre;
            objServicios.Area = servicios.Area;
            objServicios.Oferta = servicios.Oferta;
            objServicios.Valor = servicios.Valor;
            await context.SaveChangesAsync();
            return objServicios.Id;
        }

        public async Task EliminarServicios(int id)
        {
            Servicios servicios = await context.Servicios.FindAsync(id);
            context.Servicios.Remove(servicios);
            context.SaveChanges();
        }

        public async Task<List<Servicios>> ObtenerTodos()
        {
            return await context.Servicios.ToListAsync();
        }
    }
}
