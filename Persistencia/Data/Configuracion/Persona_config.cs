using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion
{
    public class Persona_config : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable("Personas");
            
            builder.Property(e => e.Nombre_persona).HasColumnType("varchar")
            .HasMaxLength(100);
            
            builder.Property(e => e.Apellido_persona).HasColumnType("varchar")
            .HasMaxLength(100);

            builder.Property(e => e.Cedula).HasColumnType("varchar")
            .HasMaxLength(100);

            builder.HasOne(e => e.Punto)
            .WithMany(e => e.Personas)
            .HasForeignKey(e => e.Id_punto_fk);
        }
    }
}