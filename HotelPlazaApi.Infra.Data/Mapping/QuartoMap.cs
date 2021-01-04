

using HotelPlazaApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelPlazaApi.Infra.Data.Mapping
{
    public class QuartoMap : IEntityTypeConfiguration<Quarto>
    {
        public void Configure(EntityTypeBuilder<Quarto> builder)
        {
            builder.ToTable("Quarto");
          
            // Primary Key
            builder.HasKey(t => new { t.QuartoId });


            builder.Property(c => c.QuartoId)
                .HasColumnName("Id");

            builder.Property(c => c.Numero)
                .HasColumnName("Numero");

            builder.Property(c => c.Descricao)
                .HasColumnName("Descricao");

            builder.Property(c => c.ArCondicionado)
                .HasColumnName("ArCondicionado");

            builder.Property(c => c.Ventilador)
                .HasColumnName("Ventilador");          
            
            builder.Property(c => c.Tv)
                .HasColumnName("Tv");

            builder.Property(c => c.Ocupado)
                .HasColumnName("Ocupado");
        }
    }
}
