using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto.Searches;
using AspMovie.Application.UseCases.Queries;
using AspMovie.Application.UseCases.Queries.Dto;
using AspMovie.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ActorController : ControllerBase
    {
        // GET: api/<ActorController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] BasePagedSearch search,
            [FromServices] IGetActorsQuery query,
            [FromServices] UseCaseHandler hendler )
        {
            return Ok(hendler.HandleQuery(query,search));
        }

       [HttpPost]
       public IActionResult Post(
           [FromBody] ActorDto dto,
           [FromServices] ICreateActorCommand command,
           [FromServices] UseCaseHandler handler  )
        {
            handler.HandleCommand(command,dto);
            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(
            int id,
            [FromServices] IDeleteActorCommand command,
            [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
