using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Implementation.Validators.Helper;
using FluentValidation;
using System.Linq;


namespace AspMovie.Implementation.Validators
{
    public class CrewValidator : AbstractValidator<CrewDto>
    {
        public readonly ProjectDbContext context;

        public CrewValidator(ProjectDbContext context)
        {
            RuleFor(x=>x.firstName)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty().WithMessage(Messages.FirstNameRequired)
                        .Matches(ValidFormatRegex.ValidNameFormat)
                        .WithMessage(ValidFormatRegex.ValidNameFormatMsg);

            RuleFor(x=>x.lastName)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty().WithMessage(Messages.LastNameRequired)
                        .Matches(ValidFormatRegex.ValidNameFormat)
                        .WithMessage(ValidFormatRegex.ValidNameFormatMsg);

            RuleFor(x=>x.movieId)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty()
                        .Must(x=>context.Movies.Any(m=>m.Id == x && m.IsActive));

            RuleFor(x=>x.jobId)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty()
                        .Must(x=>context.Jobs.Any(j=>j.Id == x && j.IsActive));
            
            this.context = context;
        }
    }
}
