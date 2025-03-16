namespace space_colonization_api.Business.Planets.Responses
{
    public record GetPlanetByIdResponse
    {
        public int PlanetId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }
}
