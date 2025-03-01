using space_colonization_api.Data.Planets;

namespace space_colonization_api.Data.Statuses
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Planet> Planets { get; set; } = [];
    }
}
