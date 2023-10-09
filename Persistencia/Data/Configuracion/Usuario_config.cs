using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion
{
    public class Usuario_config : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.Property(e => e.User_name).HasColumnType("varchar")
            .HasMaxLength(100);

            builder.Property(e => e.Password).HasColumnType("varchar")
            .HasMaxLength(100);

            builder.Property(e => e.Email).HasColumnType("varchar")
            .HasMaxLength(100);

        }
    }
}

