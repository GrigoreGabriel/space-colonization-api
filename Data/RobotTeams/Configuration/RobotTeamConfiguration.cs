using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace space_colonization_api.Data.RobotTeams.Configuration
{
    public class RobotTeamConfiguration : IEntityTypeConfiguration<RobotTeam>
    {
        public void Configure(EntityTypeBuilder<RobotTeam> builder)
        {
            builder.HasKey(tr => new { tr.TeamId, tr.RobotId, tr.ExpeditionId });

            builder.HasOne(tr => tr.Team)
                   .WithMany(t => t.RobotTeams)
                   .HasForeignKey(tr => tr.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tr => tr.Robot)
                   .WithMany(r => r.RobotTeams)
                   .HasForeignKey(tr => tr.RobotId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tr => tr.Expedition)
                   .WithMany()
                   .HasForeignKey(tr => tr.ExpeditionId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
