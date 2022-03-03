using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Datos.Config
{
    public class LugarConfiguration : IEntityTypeConfiguration<Lugar>
    {
        public void Configure(EntityTypeBuilder<Lugar> builder)
        {
            builder.Property(lugar => lugar.Id).IsRequired();
            builder.Property(l => l.Nombre).IsRequired().HasMaxLength(200);
            builder.Property(l => l.Descripcion).IsRequired();
            builder.Property(l => l.GastoAproximado).IsRequired();

            /* Relaciones RelationShip*/

            builder.HasOne(c => c.Categoria).WithMany()
                   .HasForeignKey(l => l.CategoriaID);

            builder.HasOne(p => p.Pais).WithMany()
                    .HasForeignKey(l => l.PaisID);
        }
    }
}