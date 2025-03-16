namespace space_colonization_api.Business.Planets.Responses
{
    public record GetPlanetStatusResponse
    {
        public int StatusId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
