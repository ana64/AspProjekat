using AspMovie.Application.Logging;
using AspMovie.Application.UseCases.Queries;
using AspMovie.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UseCaseLogsController : ControllerBase
    {  
       [HttpGet]
        public IActionResult Get
        (
            [FromQuery] UseCaseLogSearch search,
            [FromServices] IGetUseCaseLogsQuery query,
            [FromServices] UseCaseHandler handler
        )
        {
            return Ok(handler.HandleQuery(query,search));
         
        }
           
    }
}
