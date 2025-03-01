using space_colonization_api.Data.Planets;
using space_colonization_api.Data.Teams;

namespace space_colonization_api.Data.Expeditions
{
    public class Expedition
    {
        public int ExpeditionId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public int PlanetId { get; set; }
        public virtual Planet Planet { get; set; }

        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
    }
}
