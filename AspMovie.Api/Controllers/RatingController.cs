using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RatingController : ControllerBase
    {

        // POST api/<RatingController>
        [HttpPost]
        public IActionResult Post(
            [FromBody] RateDto dto,
            [FromServices] IRateMovieCommand command,
            [FromServices] UseCaseHandler handler)
        {
            handler.HandleCommand(command,dto);
            return StatusCode(201);
        }

       
    }
}
