using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
   public  class RepositorioProducto : IRepositorioProducto
    {
        private readonly AplicationDbContext context;
        public RepositorioProducto(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Producto productos)
        {
            context.Productos.Add(productos);
            await context.SaveChangesAsync();

            return productos.Id;
        }

        public async Task<Producto?> ObtenerPorID(int id)
        {
            return context.Productos.Where(x => x.Id == id)
            .ToList()[0];
        }

        public async Task<int> ModificarProducto(Producto productos)
        {
            Producto objProductos = await context.Productos.FindAsync(productos.Id);
            objProductos.Nombre = productos.Nombre;
            objProductos.TipoProducto = productos.TipoProducto;
            objProductos.Cantidad = productos.Cantidad;
            objProductos.FechaIngreso = productos.FechaIngreso;
            await context.SaveChangesAsync();
            return objProductos.Id;
        }

        public async Task EliminarProducto(int id)
        {
            Producto productos = await context.Productos.FindAsync(id);
            context.Productos.Remove(productos);
            context.SaveChanges();
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await context.Productos.ToListAsync();
        }
    }
}
