using space_colonization_api.Data.Teams;

namespace space_colonization_api.Data.Shuttles
{
    public class Shuttle
    {
        public int ShuttleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public virtual ICollection<Team> Teams { get; set; } = [];
    }
}
