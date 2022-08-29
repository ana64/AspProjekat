using AspMovie.Application.UseCases.Dto;

namespace AspMovie.Application.UseCases.Commands
{
    public interface ICreateMovieCommand : ICommand<CreateMovieDto>
    {
    }
}
