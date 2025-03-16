namespace space_colonization_api.Business.Planets.Responses
{
    public record GetPlanetsResponse
    {
        public int PlanetId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int RobotsOnSite { get; set; }
        public bool IsExplored { get; set; }
        public bool IsLifeSuitable { get; set; }
        public string CaptainName { get; set; } = string.Empty;
        public IEnumerable<string> Robots { get; set; } = new List<string>();
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }
}
