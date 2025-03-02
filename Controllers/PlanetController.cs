using MediatR;
using Microsoft.AspNetCore.Mvc;
using space_colonization_api.Business.Planets.Queries;
using space_colonization_api.Business.Planets.Responses;

namespace space_colonization_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlanetController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("planets")]
        public async Task<ActionResult<IReadOnlyList<GetPlanetsResponse>>> GetPlanets()
        {
            var query = await _mediator.Send(new GetPlanetsQuery());
            return Ok(query);
        }

    }
}
