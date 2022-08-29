using AspMovie.Api.Core.Dto;
using AspMovie.Api.Extensions;
using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto.Searches;
using AspMovie.Application.UseCases.Queries;
using AspMovie.Implementation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspMovie.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MovieController : ControllerBase
    {
       
        // GET: api/<MovieController>
        [HttpGet]
        public IActionResult Get(
            [FromQuery] BasePagedSearch search,
            [FromServices] IGetMoviesQuery query,
            [FromServices] UseCaseHandler handler)
        {
            return Ok(handler.HandleQuery(query,search));
        }
        // Post: api/<MovieController>
        [HttpPost]
        public IActionResult Post(
            [FromForm] CreateMovieDtoWithImage dto,
            [FromServices] ICreateMovieCommand command,
            [FromServices] UseCaseHandler handler  )
        {
             if(dto.Image != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.Image.FileName);

                if (!ImageExtensions.AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Unsupported file type.");
                }

                var fileName = guid + extension;
                var filePath = Path.Combine("root", "images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                dto.Image.CopyTo(stream);
                stream.Dispose();

                dto.PosterFileName = fileName;
            }
            
            handler.HandleCommand(command,dto);
            return StatusCode(201);
        }

       
    }
}
