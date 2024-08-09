using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public class RepositorioSalida : IRepositorioSalida
    {
        private readonly AplicationDbContext context;
        public RepositorioSalida(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Salida salida)
        {
            context.Salidas.Add(salida);
            await context.SaveChangesAsync();

            return salida.Id;
        }

        public async Task<Salida?> ObtenerPorID(int id)
        {
            return context.Salidas.Where(salida => salida.Id == id)
                 .ToList()[0];

        }

        public async Task EliminarSalida(int id)
        {
            Salida salida = await context.Salidas.FindAsync(id);
            context.Salidas.Remove(salida);
            context.SaveChanges();
        }

        public async Task<int> ModificarSalida(Salida salida)
        {
            Salida objSalida = await context.Salidas.FindAsync(salida.Id);
            objSalida.Producto = salida.Producto;
            objSalida.TipoProducto = salida.TipoProducto;
            objSalida.Cantidad = salida.Cantidad;
            objSalida.FechaSalida = salida.FechaSalida;
            objSalida.Descripcion = salida.Descripcion;
            await context.SaveChangesAsync();
            return objSalida.Id;
        }

        public async Task<List<Salida>> ObtenerTodos()
        {
            return await context.Salidas.ToListAsync();
        }
    }
}
