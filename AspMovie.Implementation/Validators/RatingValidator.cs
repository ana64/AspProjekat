using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMovie.Implementation.Validators
{
    public class RatingValidator : AbstractValidator<RateDto>
    {
        public readonly ProjectDbContext context;

        public RatingValidator(ProjectDbContext context)
        {
            RuleFor(x => x.movieId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(x =>context.Movies.Any(m=>m.Id ==x)).WithMessage("Movie doesn't exist") ;

            RuleFor(x => x.userId)
               .Cascade(CascadeMode.Stop)
               .NotEmpty()
               .Must(x => context.Users.Any(u => u.Id == x)).WithMessage("User doesn't exist");

            RuleFor(x => x.star)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithName("Star")
               .GreaterThan(0)
               .LessThanOrEqualTo(10);


            this.context = context;
        }
    }
}
