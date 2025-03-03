using MediatR;
using space_colonization_api.Business.Planets.Responses;

namespace space_colonization_api.Business.Planets.Queries
{
    public record GetPlanetsQuery : IRequest<IReadOnlyList<GetPlanetsResponse>>
    {
    }
}
