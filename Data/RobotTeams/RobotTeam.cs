using space_colonization_api.Data.Expeditions;
using space_colonization_api.Data.Robots;
using space_colonization_api.Data.Teams;

namespace space_colonization_api.Data.RobotTeams
{
    public class RobotTeam
    {
        public int TeamId { get; set; }
        public required virtual Team Team { get; set; }

        public int RobotId { get; set; }
        public virtual Robot Robot { get; set; }

        public int ExpeditionId { get; set; }
        public virtual Expedition Expedition { get; set; }
    }
}
