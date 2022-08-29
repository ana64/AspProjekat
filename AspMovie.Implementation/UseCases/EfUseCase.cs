using AspMovie.DataAccess;


namespace AspMovie.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(ProjectDbContext context)
        {
            Context = context;
        }

        protected ProjectDbContext Context { get; }
    }
}
