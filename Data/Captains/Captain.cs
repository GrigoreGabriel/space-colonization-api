using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using space_colonization_api.Data.Teams;

namespace space_colonization_api.Data.Captains
{
    public class Captain
    {
        public int CaptainId { get; set; }
        public string Name { get; set; } = "";
        public virtual Team Team { get; set; }
    }


    public static class CaptainEndpoints
    {
        public static void MapCaptainEndpoints(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/api/Captain").WithTags(nameof(Captain));

            group.MapGet("/", async (SpaceDbContext db) =>
            {
                return await db.Captains.ToListAsync();
            })
            .WithName("GetAllCaptains")
            .WithOpenApi();

            group.MapGet("/{id}", async Task<Results<Ok<Captain>, NotFound>> (int captainid, SpaceDbContext db) =>
            {
                return await db.Captains.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.CaptainId == captainid)
                    is Captain model
                        ? TypedResults.Ok(model)
                        : TypedResults.NotFound();
            })
            .WithName("GetCaptainById")
            .WithOpenApi();

            group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int captainid, Captain captain, SpaceDbContext db) =>
            {
                var affected = await db.Captains
                    .Where(model => model.CaptainId == captainid)
                    .ExecuteUpdateAsync(setters => setters
                      .SetProperty(m => m.CaptainId, captain.CaptainId)
                      .SetProperty(m => m.Name, captain.Name)
                      );
                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateCaptain")
            .WithOpenApi();

            group.MapPost("/", async (Captain captain, SpaceDbContext db) =>
            {
                db.Captains.Add(captain);
                await db.SaveChangesAsync();
                return TypedResults.Created($"/api/Captain/{captain.CaptainId}", captain);
            })
            .WithName("CreateCaptain")
            .WithOpenApi();

            group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int captainid, SpaceDbContext db) =>
            {
                var affected = await db.Captains
                    .Where(model => model.CaptainId == captainid)
                    .ExecuteDeleteAsync();
                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteCaptain")
            .WithOpenApi();
        }
    }
}
