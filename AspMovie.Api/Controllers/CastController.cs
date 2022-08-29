using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspMovie.Api.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CastController : ControllerBase
    {
        /// <summary>
        /// Insert in AuthorMovie table
        /// { actorid,
        /// movieId,
        /// Role }
        /// </summary>
        [HttpPost]
        public IActionResult Post(
            [FromBody] CastDto dto,
            [FromServices] IAddMovieCastCommand command,
            [FromServices] UseCaseHandler handler )
        {
            handler.HandleCommand(command, dto);
            return StatusCode(201);
        }
    }
}
