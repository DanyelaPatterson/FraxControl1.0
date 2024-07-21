using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FraxControl.Entities.Configurations
{
    public class VehiculoConfig : IEntityTypeConfiguration<VehiculoEntity>
    {
        public void Configure(EntityTypeBuilder<VehiculoEntity> builder)
        {
            builder.Property(v=>v.Placas).HasMaxLength(7);
            builder.Property(v=>v.Owner).HasMaxLength(80);
            builder.Property(v=>v.Marca).HasMaxLength(50);
            builder.Property(v=>v.Direccion).HasMaxLength(100);
            builder.Property(v=>v.Modelo).HasMaxLength(20);
        }

    }
}