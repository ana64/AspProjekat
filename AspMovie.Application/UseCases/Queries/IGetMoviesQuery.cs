using AspMovie.Application.UseCases.Dto;
using AspMovie.Application.UseCases.Dto.Searches;
using System.Collections.Generic;


namespace AspMovie.Application.UseCases.Queries
{
    public interface IGetMoviesQuery : IQuery<BasePagedSearch,IEnumerable<MovieDto>> { }
}
