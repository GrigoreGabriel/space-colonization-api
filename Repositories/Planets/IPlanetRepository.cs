using space_colonization_api.Business.Planets.Responses;

namespace space_colonization_api.Repositories.Planets
{
    public interface IPlanetRepository
    {
        public Task<IReadOnlyList<GetPlanetsResponse>> GetAll(CancellationToken cancellationToken);

    }
}
