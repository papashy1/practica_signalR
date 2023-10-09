using System.Reflection;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Persistencia
{
    public class Puestico_context : DbContext
    {
        public Puestico_context(DbContextOptions<Puestico_context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Persona>()
        .HasOne<Usuario>(p => p.Usuario)
        .WithOne(ad => ad.Persona)
        .HasForeignKey<Usuario>(ad => ad.Id_persona_fk);
    }
        public DbSet<Punto> Puntos {get; set; }
        public DbSet<Persona> Personas {get; set; }
        public DbSet<Usuario> Usuarios {get; set; }
    }
}