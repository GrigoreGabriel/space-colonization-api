using space_colonization_api.Data.Teams;

namespace space_colonization_api.Data.Captains
{
    public class Captain
    {
        public int CaptainId { get; set; }
        public string Name { get; set; } = "";
        public virtual Team Team { get; set; }
    }
}
