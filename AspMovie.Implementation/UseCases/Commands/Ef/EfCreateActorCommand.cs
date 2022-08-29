using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Queries;
using AspMovie.Application.UseCases.Queries.Dto;
using AspMovie.DataAccess;
using AspMovie.Domain.Entities;
using AspMovie.Implementation.Validators;
using FluentValidation;


namespace AspMovie.Implementation.UseCases.Commands.Ef
{
    public class EfCreateActorCommand : EfUseCase,ICreateActorCommand
    {
        private readonly ActorValidator validator;

        public EfCreateActorCommand(ProjectDbContext context,ActorValidator validator)
            : base(context)
        {
            this.validator = validator;
        }

        public int Id => 4;

        public string Name =>"Create Actor";

        public string Description => "using ef";

        public void Execute(ActorDto request)
        {
            validator.ValidateAndThrow(request);
            var actor = new Actor
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Biography = request.Biography,
                Born    = request.Birthday,     
            };

            Context.Add(actor);
            Context.SaveChanges();  
        }

    }
}
