using AspMovie.Application.UseCases.Dto;
using Microsoft.AspNetCore.Http;

namespace AspMovie.Api.Core.Dto
{
    public class CreateMovieDtoWithImage : CreateMovieDto
    {
        public IFormFile Image { get; set; }

    }
}
