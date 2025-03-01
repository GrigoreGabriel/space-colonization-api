using space_colonization_api.Data.Expeditions;
using space_colonization_api.Data.Statuses;

namespace space_colonization_api.Data.Planets
{
    public class Planet
    {
        public int PlanetId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int RobotsOnSite { get; set; }
        public bool IsExplored { get; set; }
        public bool IsLifeSuitable { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public ICollection<Expedition> Expeditions { get; set; } = [];
    }
}
