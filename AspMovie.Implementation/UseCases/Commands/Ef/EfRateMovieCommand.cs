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
    public class EfRateMovieCommand : EfUseCase, IRateMovieCommand
    {
        public readonly RatingValidator validator;
        public EfRateMovieCommand(ProjectDbContext context, RatingValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 8;

        public string Name => "Rating Movie";

        public string Description => "Add new record in pivot table Rating using entity framework";

        public void Execute(RateDto request)
        {
            validator.ValidateAndThrow(request);

            var rate = new Rating
            {
                MovieId = request.movieId,
                UserId = request.userId,
                Star = request.star
            };
            Context.Add(rate);
            Context.SaveChanges();
        }
    }
}
