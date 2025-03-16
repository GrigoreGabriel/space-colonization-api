using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using space_colonization_api.Business.Planets.Commands;
using space_colonization_api.Business.Planets.Queries;
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
                .Include(e => e.Expeditions)
                    .ThenInclude(t => t.Team)
                        .ThenInclude(c => c.Captain)
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
                    StatusId = p.StatusId,
                    StatusName = p.Status.Name,
                    CaptainName = p.Expeditions
                            .Where(p => p.PlanetId == p.PlanetId)
                            .OrderBy(e => e.StartDate)
                            .Select(e => e.Team.Captain.Name)
                            .FirstOrDefault() ?? "N/A",
                    Robots = p.Expeditions
                        .Where(x => x.PlanetId == x.PlanetId)
                        .SelectMany(e => e.Team.RobotTeams.Select(rt => rt.Robot.Name))
                        .Distinct()
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<GetPlanetByIdResponse> GetById(GetPlanetByIdQuery query, CancellationToken cancellationToken)
        {
            var planet = await _Dbcontext.Planets
            .Include(p => p.Status)
            .FirstOrDefaultAsync(p => p.PlanetId == query.Id, cancellationToken);

            if (planet is null)
            {
                return null;
            }
            return new GetPlanetByIdResponse
            {
                PlanetId = planet.PlanetId,
                Name = planet.Name,
                Description = planet.Description,
                StatusId = planet.StatusId,
                StatusName = planet.Status.Name,
            };

        }

        public async Task<IReadOnlyList<GetPlanetStatusResponse>> GetStatuses(GetPlanetStatusQuery query, CancellationToken cancellationToken)
        {
            return await _Dbcontext.Statuses
                .Select(x => new GetPlanetStatusResponse
                {
                    StatusId = x.StatusId,
                    Name = x.Name
                }).ToListAsync(cancellationToken);
        }

        public async Task<IActionResult> UpdatePlanetDetails(UpdatePlanetDetailsCommand command, CancellationToken cancellationToken)
        {
            if (command is null)
            {
                return new BadRequestObjectResult("Command cannot be null.");
            }

            var planet = await _Dbcontext.Planets
                .FirstOrDefaultAsync(p => p.PlanetId == command.PlanetId, cancellationToken);

            if (planet is null)
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
                // pretend I'm logging here :)
                return new StatusCodeResult(500);
            }

            return new OkObjectResult(planet);
        }
    }
}
