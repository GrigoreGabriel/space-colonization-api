using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace space_colonization_api.Data.Expeditions.Configuration
{
    public class ExpeditionConfiguration : IEntityTypeConfiguration<Expedition>
    {
        public void Configure(EntityTypeBuilder<Expedition> builder)
        {
            builder.HasKey(e => e.ExpeditionId);

            builder.Property(e => e.StartDate)
                   .IsRequired();

            builder.Property(e => e.EndDate)
                   .IsRequired(false);

            builder.HasOne(e => e.Planet)
                   .WithMany(p => p.Expeditions)
                   .HasForeignKey(e => e.PlanetId);

            builder.HasOne(e => e.Team)
                   .WithMany()
                   .HasForeignKey(e => e.TeamId);

        }
    }
}
