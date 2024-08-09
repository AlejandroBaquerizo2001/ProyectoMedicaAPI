using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMedica.Entidades
{
    public class AplicationDbContext : DbContext
    {
         

        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
 /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=tallerdawa;Integrated Security=True; TrustServerCertificate=True;");
        }
*/
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Adquirido > Adquiridos { get; set; }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<Historial> Historiales { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Salida> Salidas { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
    }
}
