using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Implementation.Validators.Helper;
using FluentValidation;
using System.Linq;


namespace AspMovie.Implementation.Validators
{
    public class CastValidator : AbstractValidator<CastDto>
    {
        public readonly ProjectDbContext context;

        public CastValidator(ProjectDbContext context)
        {
            RuleFor(x=>x.movieId)
                       .Cascade(CascadeMode.Stop)
                       .NotEmpty()
                       .Must(x=>context.Movies.Any(m=>m.Id==x));

            RuleFor(x => x.actorId)
                         .Cascade(CascadeMode.Stop)
                         .NotEmpty()
                         .Must(x => context.Actors.Any(a => a.Id == x));


            RuleFor(x => x.Role)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty()
                        .Matches(ValidFormatRegex.ValidNameFormat);


            this.context = context;
        }
    }
}
