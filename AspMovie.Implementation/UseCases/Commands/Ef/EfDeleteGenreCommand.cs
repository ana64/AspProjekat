using AspMovie.Application.Exceptions;
using AspMovie.Application.UseCases.Commands;
using AspMovie.DataAccess;
using AspMovie.Domain.Entities;
using System.Linq;


namespace AspMovie.Implementation.UseCases.Commands.Ef
{
    public class EfDeleteGenreCommand : EfUseCase,IDeleteGenreCommand
    {
        public EfDeleteGenreCommand(ProjectDbContext context) 
          : base(context)
        {
        }

        public int Id => 1;

        public string Name => "Delete Genre";

        public string Description => "";

        public void Execute(int request)
        {
           var genre = Context.Genres.FirstOrDefault(x => x.Id == request && x.IsActive);

           if (genre == null)
           {
                throw new EntityNotFoundException(nameof(Genre), request);
           }

            if (genre.Movies.Any())
            {
                throw new UseCaseConflictException("Can't delete genre because of it's link to movies: "
                                                   + string.Join(", ", genre.Movies.Select(x => x.Title)));
            }

            Context.Genres.Remove(genre);
            Context.SaveChanges();
        }
    }
}
