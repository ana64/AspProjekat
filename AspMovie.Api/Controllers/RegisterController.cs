using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post
        (
            [FromBody] RegisterDto dto,
            [FromServices] IRegisterUserCommand command,
            [FromServices] UseCaseHandler handler
        )
        {
            handler.HandleCommand(command,dto);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
