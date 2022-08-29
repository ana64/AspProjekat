
namespace AspMovie.Application.UseCases
{
    public interface IQuery<TRequest,TResult> :IUseCase
    {
        TResult Execute (TRequest request);
    }
}
