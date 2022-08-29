using AspMovie.Application.UseCases.Commands;
using AspMovie.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserUseCasesController : ControllerBase
    {
        
        [HttpPut]
        public IActionResult Put  (
         [FromBody] UpdateUserUseCasesDto request,
         [FromServices] IUpdateUserUseCasesCommand command ,
         [FromServices] UseCaseHandler handler
        )
        {
            handler.HandleCommand(command, request);
            return NoContent();
        }

    }
}
