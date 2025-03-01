using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace space_colonization_api.Data.Teams.NewFolder
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(t => t.TeamId);

            builder.HasOne(t => t.Captain)
                   .WithOne(c => c.Team)
                   .HasForeignKey<Team>(t => t.CaptainId);

            builder.HasOne(t => t.Shuttle)
                   .WithMany(s => s.Teams)
                   .HasForeignKey(t => t.ShuttleId);

            builder.HasMany(t => t.RobotTeams)
                   .WithOne(tr => tr.Team)
                   .HasForeignKey(tr => tr.TeamId);
        }
    }
}
