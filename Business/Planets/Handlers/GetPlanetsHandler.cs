using MediatR;
using space_colonization_api.Business.Planets.Queries;
using space_colonization_api.Business.Planets.Responses;
using space_colonization_api.Repositories.Planets;

namespace space_colonization_api.Business.Planets.Handlers
{
    public class GetPlanetsHandler : IRequestHandler<GetPlanetsQuery, IReadOnlyList<GetPlanetsResponse>>
    {
        public readonly IPlanetRepository _planetRepository;

        public GetPlanetsHandler(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public async Task<IReadOnlyList<GetPlanetsResponse>> Handle(GetPlanetsQuery request, CancellationToken cancellationToken)
        {
            return await _planetRepository.GetAll(cancellationToken);
        }
    }
}
