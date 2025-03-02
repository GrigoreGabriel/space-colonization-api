
using Microsoft.EntityFrameworkCore;
using space_colonization_api.Business.Planets.Responses;
using space_colonization_api.Data;

namespace space_colonization_api.Repositories.Planets
{
    public class PlanetRepository : IPlanetRepository
    {
        public readonly SpaceDbContext _Dbcontext;
        public PlanetRepository(SpaceDbContext dbContext)
        {
            _Dbcontext = dbContext;
        }
        public async Task<IReadOnlyList<GetPlanetsResponse>> GetAll(CancellationToken cancellationToken)
        {
            return await _Dbcontext.Planets
                .Select(p => new GetPlanetsResponse
                {
                    PlanetId = p.PlanetId,
                    Name = p.Name,
                    Image = p.Image,
                    Description = p.Description,
                    RobotsOnSite = p.RobotsOnSite,
                    IsExplored = p.IsExplored,
                    IsLifeSuitable = p.IsLifeSuitable,
                    StatusName = p.Status.Name
                })
                .ToListAsync(cancellationToken);
        }
    }
}
