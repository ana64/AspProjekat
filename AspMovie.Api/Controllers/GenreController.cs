using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.Application.UseCases.Dto.Searches;
using AspMovie.Application.UseCases.Queries;
using AspMovie.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenreController : ControllerBase
    {
        private UseCaseHandler handler;

        public GenreController(UseCaseHandler handler)
        {
            this.handler = handler;
        }

        // GET: api/<GenreController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] BasePagedSearch search, 
            [FromServices] IGetGenresQuery query
        )
        {
            return Ok(handler.HandleQuery(query, search)); ;
        }


        // POST api/<GenreController>
        [HttpPost]
        //[Authorize]
        public IActionResult Post(
            [FromBody] GenreDto dto,
            [FromServices] ICreateGenreCommand command  )
        {
            handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        //PUT api/<GenreController>
        [HttpPut]
        //[Authorize]
        public IActionResult Put(
         [FromBody]GenreDto dto,
         [FromServices] IUpdateGenreCommand command )
        {
            handler.HandleCommand(command,dto);
            return NoContent(); 
        }

        // DELETE api/<GenreController>/5
        [HttpDelete("{id}")]
        //[Authorize]
        public IActionResult Delete(
            int id, 
            [FromServices] IDeleteGenreCommand command )
        {
            handler.HandleCommand(command, id);
            return NoContent();
        }
    }
}
