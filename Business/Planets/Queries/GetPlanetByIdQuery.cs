using MediatR;
using space_colonization_api.Business.Planets.Responses;

namespace space_colonization_api.Business.Planets.Queries
{
    public record GetPlanetByIdQuery : IRequest<GetPlanetByIdResponse>
    {
        public GetPlanetByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
