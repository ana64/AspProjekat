using AspMovie.Application.UseCases.Dto.Searches;
using AspMovie.Application.UseCases.Queries.Dto;

namespace AspMovie.Application.UseCases.Queries
{
    public interface IGetActorsQuery : IQuery<BasePagedSearch,PagedResponse<ActorDto>>
    {
    }
}
