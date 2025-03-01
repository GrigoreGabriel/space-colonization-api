using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace space_colonization_api.Data.Planets.Configuration
{
    public class PlanetConfiguration : IEntityTypeConfiguration<Planet>
    {
        public void Configure(EntityTypeBuilder<Planet> builder)
        {
            builder.HasKey(x => x.PlanetId);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(p => p.IsExplored)
                   .IsRequired();

            builder.HasMany(p => p.Expeditions)
                   .WithOne(e => e.Planet)
                   .HasForeignKey(e => e.PlanetId);

            builder.HasOne(e => e.Status)
               .WithMany(s => s.Planets)
               .HasForeignKey(e => e.StatusId);
        }
    }
}
