using MediatR;
using space_colonization_api.Business.Planets.Queries;
using space_colonization_api.Business.Planets.Responses;
using space_colonization_api.Repositories.Planets;

namespace space_colonization_api.Business.Planets.Handlers
{
    public class GetPlanetByIdHandler : IRequestHandler<GetPlanetByIdQuery, GetPlanetByIdResponse>
    {
        public readonly IPlanetRepository _planetRepository;

        public GetPlanetByIdHandler(IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public async Task<GetPlanetByIdResponse> Handle(GetPlanetByIdQuery query, CancellationToken cancellationToken)
        {
            return await _planetRepository.GetById(query, cancellationToken);
        }
    }
}
