using Microsoft.EntityFrameworkCore;
using ProyectoMedica.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Repositorio
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly AplicationDbContext context;
        public RepositorioUsuario(AplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Crear(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            await context.SaveChangesAsync();

            return usuario.Id;
        }

        public async Task<Usuario?> ObtenerPorID(int id)
        {
            return context.Usuarios.Where(x => x.Id == id)
                .ToList()[0];
        }

        public async Task<int> ModificarUsuario(Usuario usuario)
        {
            Usuario objUsuario = await context.Usuarios.FindAsync(usuario.Id);
            objUsuario.Nombre = usuario.Nombre;
            objUsuario.Identidad = usuario.Identidad;
            objUsuario.Correo = usuario.Correo;
            objUsuario.Clave = usuario.Clave;
            await context.SaveChangesAsync();
            return objUsuario.Id;
        }

        public async Task EliminarUsuario(int id)
        {
            Usuario usuario = await context.Usuarios.FindAsync(id);
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
        }

        public async Task<List<Usuario>> ObtenerTodos()
        {
            return await context.Usuarios.ToListAsync();
        }
    }
}
