using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMovie.Implementation.UseCases.Commands.Ef
{
    public class EfUpdateGenreCommand : EfUseCase, IUpdateGenreCommand
    {
        private GenreValidator validator;
        public EfUpdateGenreCommand(ProjectDbContext context, GenreValidator validator = null)
        : base(context)
        {
            this.validator = validator;
        }

        public int Id => 8;

        public string Name => "Update Genre";

        public string Description =>"Update Genre Name (entity framework)";

        public void Execute(GenreDto request)
        {
            validator.ValidateAndThrow(request);

            var genre = Context.Genres.Find(request.Id);

            if (genre == null)
            {
                genre.GenreName = request.Genre;
                Context.SaveChanges();
            }
        }
    }
}
