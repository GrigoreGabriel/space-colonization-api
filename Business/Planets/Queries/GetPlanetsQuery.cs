using MediatR;
using space_colonization_api.Business.Planets.Responses;

namespace space_colonization_api.Business.Planets.Queries
{
    public class GetPlanetsQuery : IRequest<IReadOnlyList<GetPlanetsResponse>>
    {

    }
}
