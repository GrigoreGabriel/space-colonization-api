namespace space_colonization_api.Business.Planets.Requests
{
    public record UpdatePlanetDetailsRequest
    {
        public UpdatePlanetDetailsRequest(string description, int? statusId)
        {

            Description = description;
            StatusId = statusId;
        }
        public string Description { get; set; } = string.Empty;
        public int? StatusId { get; set; }
    }

}
