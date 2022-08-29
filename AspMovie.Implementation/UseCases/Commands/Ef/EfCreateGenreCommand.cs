using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Domain.Entities;
using FluentValidation;
using AspMovie.Implementation.Validators;

namespace AspMovie.Implementation.UseCases.Commands.Ef
{
    public class EfCreateGenreCommand : EfUseCase, ICreateGenreCommand
    {
        private readonly GenreValidator validator;
        public EfCreateGenreCommand(ProjectDbContext context, GenreValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 3;

        public string Name => "Create Genre";

        public string Description => "Create genre using entity framework";

        public void Execute(GenreDto request)
        {
            validator.ValidateAndThrow(request);

            var genre = new Genre
            {
                GenreName = request.Genre,
                Id = request.Id

            };

            Context.Genres.Add(genre);
            Context.SaveChanges();
        }

    }
}
