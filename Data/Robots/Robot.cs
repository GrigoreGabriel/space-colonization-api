using space_colonization_api.Data.RobotTeams;

namespace space_colonization_api.Data.Robots
{
    public class Robot
    {
        public int RobotId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<RobotTeam> RobotTeams { get; set; } = [];
    }
}
