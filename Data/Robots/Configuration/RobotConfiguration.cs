using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace space_colonization_api.Data.Robots.Configuration
{
    public class RobotConfiguration : IEntityTypeConfiguration<Robot>
    {
        public void Configure(EntityTypeBuilder<Robot> builder)
        {
            builder.HasKey(r => r.RobotId);

            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(r => r.RobotTeams)
                   .WithOne(tr => tr.Robot)
                   .HasForeignKey(tr => tr.RobotId);
        }
    }
}
