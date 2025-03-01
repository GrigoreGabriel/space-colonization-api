using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using space_colonization_api.Data.Teams;

namespace space_colonization_api.Data.Captains.Configuration
{
    public class CaptainConfiguration : IEntityTypeConfiguration<Captain>
    {
        public void Configure(EntityTypeBuilder<Captain> builder)
        {
            builder.HasKey(c => c.CaptainId);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasOne(c => c.Team)
                   .WithOne(t => t.Captain)
                   .HasForeignKey<Team>(t => t.CaptainId);
        }
    }
}
