using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using space_colonization_api.Business.Planets.Commands;
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
                .AsNoTracking()
                .Select(p => new GetPlanetsResponse
                {
                    PlanetId = p.PlanetId,
                    Name = p.Name,
                    Image = p.ImagePath,
                    Description = p.Description,
                    RobotsOnSite = p.RobotsOnSite,
                    IsExplored = p.IsExplored,
                    IsLifeSuitable = p.IsLifeSuitable,
                    StatusName = p.Status.Name
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<IActionResult> UpdatePlanetDetails(UpdatePlanetDetailsCommand command, CancellationToken cancellationToken)
        {
            if (command == null)
            {
                return new BadRequestObjectResult("Command cannot be null.");
            }

            var planet = await _Dbcontext.Planets
                .FirstOrDefaultAsync(p => p.PlanetId == command.PlanetId, cancellationToken);

            if (planet == null)
            {
                return new NotFoundResult();
            }

            if (!string.IsNullOrEmpty(command.Description))
            {
                planet.Description = command.Description;
            }

            if (command.StatusId.HasValue)
            {
                planet.StatusId = command.StatusId.Value;
            }

            try
            {
                await _Dbcontext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                // logging with ex.Message
                return new StatusCodeResult(500);
            }

            return new OkObjectResult(planet);
        }
    }
}
