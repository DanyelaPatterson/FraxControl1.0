using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FraxControl.Entities.Configurations
{
    public class VisitaConfig
    {
        public void Configure (EntityTypeBuilder<VisitaEntity> builder)
        {
            builder.Property(v=>v.Name).HasMaxLength(80);
            builder.Property(v=>v.FechaVisita).HasColumnType("date");
            builder.Property(v=>v.Marca).HasMaxLength(50);
            builder.Property(v=>v.Modelo).HasMaxLength(20);
            builder.Property(v=>v.Apellido).HasMaxLength(80);
            builder.Property(v=>v.Placas).HasMaxLength(7);
        }
    }
}