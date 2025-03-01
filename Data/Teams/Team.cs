using space_colonization_api.Data.Captains;
using space_colonization_api.Data.RobotTeams;
using space_colonization_api.Data.Shuttles;

namespace space_colonization_api.Data.Teams
{
    public class Team
    {
        public int TeamId { get; set; }

        public int CaptainId { get; set; }
        public virtual Captain Captain { get; set; }

        public int ShuttleId { get; set; }
        public virtual Shuttle Shuttle { get; set; }

        public ICollection<RobotTeam> RobotTeams { get; set; } = [];
    }
}
