using AspMovie.Application.Exceptions;
using AspMovie.Application.UseCases.Commands;
using AspMovie.DataAccess;
using AspMovie.Domain.Entities;
using System.Linq;


namespace AspMovie.Implementation.UseCases.Commands.Ef
{
    public class EfDeleteActorCommand :EfUseCase, IDeleteActorCommand
    {
        public EfDeleteActorCommand(ProjectDbContext context) : base(context)
        {
        }

        public int Id =>5;

        public string Name => "Delete Actor Command";

        public string Description => "";

        public void Execute(int request)
        {
            var actor = Context.Actors.FirstOrDefault(a => a.Id == request && a.IsActive);

            if(actor == null)
            {
                throw new EntityNotFoundException(nameof(Actor),request);
            }
            if (actor.ActorMovies.Any())
            {
                throw new UseCaseConflictException("Can't delete actor ");
            }

            Context.Remove(actor);
            Context.SaveChanges();
        }
    }
}
