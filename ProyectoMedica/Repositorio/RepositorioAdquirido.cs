using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public class RepositorioAdquirido : IRepositorioAdquirido
    {
        private readonly AplicationDbContext context;
        public RepositorioAdquirido(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Adquirido adquirido)
        {
            context.Adquiridos.Add(adquirido);
            await context.SaveChangesAsync();

            return adquirido.Id;
        }

        public async Task<Adquirido?> ObtenerPorID(int id)
        {
            return context.Adquiridos.Where(adquirido => adquirido.Id == id)
                 .ToList()[0];

        }

        public async Task EliminarAdquirido(int id)
        {
            Adquirido adquirido = await context.Adquiridos.FindAsync(id);
            context.Adquiridos.Remove(adquirido);
            context.SaveChanges();
        }

        public async Task<int> ModificarAdquirido(Adquirido adquirido)
        {
            Adquirido objAdquirido = await context.Adquiridos.FindAsync(adquirido.Id);
            objAdquirido.Producto = adquirido.Producto;
            objAdquirido.Usuario= adquirido.Usuario;
            objAdquirido.Valor = adquirido.Valor;
            objAdquirido.FechaAdquirido = adquirido.FechaAdquirido;
            await context.SaveChangesAsync();
            return objAdquirido.Id;
        }

        public async Task<List<Adquirido>> ObtenerTodos()
        {
            return await context.Adquiridos.ToListAsync();
        }
    }
}
