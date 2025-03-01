using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace space_colonization_api.Data.Shuttles.Configuration
{
    public class ShuttleConfiguration : IEntityTypeConfiguration<Shuttle>
    {
        public void Configure(EntityTypeBuilder<Shuttle> builder)
        {
            builder.HasKey(s => s.ShuttleId);

            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Capacity)
                   .IsRequired();

            builder.HasMany(s => s.Teams)
                   .WithOne(t => t.Shuttle)
                   .HasForeignKey(t => t.ShuttleId);
        }
    }
}
