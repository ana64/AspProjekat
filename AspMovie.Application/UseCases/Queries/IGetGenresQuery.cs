using AspMovie.Application.UseCases.Dto;
using AspMovie.Application.UseCases.Dto.Searches;


namespace AspMovie.Application.UseCases.Queries
{
    public interface IGetGenresQuery : IQuery<BasePagedSearch, PagedResponse<GenreDto>> { }
}
