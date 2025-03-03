using MediatR;
using Microsoft.AspNetCore.Mvc;
using space_colonization_api.Business.Planets.Commands;
using space_colonization_api.Repositories.Planets;

namespace space_colonization_api.Business.Planets.Handlers
{
    public class UpdatePlanetDetailsHandler : IRequestHandler<UpdatePlanetDetailsCommand, IActionResult>
    {
        public readonly IPlanetRepository _planetRepository;

        public UpdatePlanetDetailsHandler(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public async Task<IActionResult> Handle(UpdatePlanetDetailsCommand command, CancellationToken cancellationToken)
        {
            return await _planetRepository.UpdatePlanetDetails(command, cancellationToken);
        }
    }
}
