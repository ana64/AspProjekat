using AspMovie.Application.UseCases.Dto;

namespace AspMovie.Application.UseCases.Commands
{
    public interface IAddMovieCastCommand : ICommand<CastDto>
    {
    }
}
