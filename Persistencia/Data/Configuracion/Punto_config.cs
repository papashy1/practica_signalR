using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuracion
{
    public class Punto_config : IEntityTypeConfiguration<Punto>
    {
        public void Configure(EntityTypeBuilder<Punto> builder)
        {
            builder.ToTable("Puntos");
            
            builder.Property(e => e.Nombre_punto).HasColumnType("varchar").HasColumnName("Nombre del Punto")
            .HasMaxLength(100);
        }
    }
}