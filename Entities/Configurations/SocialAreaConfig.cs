using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FraxControl.Entities.Configurations
{
    public class SocialAreaConfig : IEntityTypeConfiguration<SocialAreaEntity>
    {
        public void Configure(EntityTypeBuilder<SocialAreaEntity> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(80);
            builder.Property(e => e.Apellido).HasMaxLength(80);
        }
    }
}