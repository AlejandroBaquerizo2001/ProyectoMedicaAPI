using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public class RepositorioInventario : IRepositorioInventario
    {
        private readonly AplicationDbContext context;
        public RepositorioInventario(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Inventario inventario)
        {
            context.Inventarios.Add(inventario);
            await context.SaveChangesAsync();

            return inventario.Id;
        }

        public async Task<Inventario?> ObtenerPorID(int id)
        {
            return context.Inventarios.Where(inventario => inventario.Id == id)
                 .ToList()[0];

        }

        public async Task EliminarInventario(int id)
        {
            Inventario inventario = await context.Inventarios.FindAsync(id);
            context.Inventarios.Remove(inventario);
            context.SaveChanges();
        }

        public async Task<int> ModificarInventario(Inventario inventario)
        {
            Inventario objInventario = await context.Inventarios.FindAsync(inventario.Id);
            objInventario.Producto = inventario.Producto;
            objInventario.TipoProducto = inventario.TipoProducto;
            objInventario.Cantidad = inventario.Cantidad;
            objInventario.Estado = inventario.Estado;
            await context.SaveChangesAsync();
            return objInventario.Id;
        }

        public async Task<List<Inventario>> ObtenerTodos()
        {
            return await context.Inventarios.ToListAsync();
        }
    }
}
