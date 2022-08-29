using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Domain.Entities;
using AspMovie.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMovie.Implementation.UseCases.Commands.Ef
{
    public class EfAddMovieCastCommand : EfUseCase,IAddMovieCastCommand
    {
        public readonly CastValidator validator;
        public EfAddMovieCastCommand(ProjectDbContext context, CastValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 10;

        public string Name => "Movie Cast";

        public string Description => "";

        public void Execute(CastDto request)
        {
             validator.ValidateAndThrow(request);

            var actor = Context.Actors.FirstOrDefault(x => x.Id == request.actorId && x.IsActive);
            var movie = Context.Movies.FirstOrDefault(x => x.Id == request.movieId && x.IsActive);


            var cast = new ActorMovie
            {
              Actor = actor,
              Movie = movie,
              Role  = request.Role
            };

            Context.ActorMovies.Add(cast);
            Context.SaveChanges();
            
        }
    }
}
