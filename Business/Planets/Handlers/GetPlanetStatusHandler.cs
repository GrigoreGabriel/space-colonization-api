using MediatR;
using space_colonization_api.Business.Planets.Queries;
using space_colonization_api.Business.Planets.Responses;
using space_colonization_api.Repositories.Planets;

namespace space_colonization_api.Business.Planets.Handlers
{
    public class GetPlanetStatusHandler : IRequestHandler<GetPlanetStatusQuery, IReadOnlyList<GetPlanetStatusResponse>>
    {
        public readonly IPlanetRepository _planetRepository;

        public GetPlanetStatusHandler(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public async Task<IReadOnlyList<GetPlanetStatusResponse>> Handle(GetPlanetStatusQuery request, CancellationToken cancellationToken)
        {
            return await _planetRepository.GetStatuses(request, cancellationToken);
        }
    }
}
