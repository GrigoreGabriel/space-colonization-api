using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace space_colonization_api.Business.Planets.Commands
{
    public class UpdatePlanetDetailsCommand : IRequest<IActionResult>
    {

        public UpdatePlanetDetailsCommand(int planetId, string description, int? statusId)
        {
            PlanetId = planetId;
            Description = description;
            StatusId = statusId;
        }

        public int PlanetId { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? StatusId { get; set; }
    }
}
