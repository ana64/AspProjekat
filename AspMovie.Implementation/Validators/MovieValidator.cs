using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Implementation.Validators.Helper;
using FluentValidation;
using System.Linq;


namespace AspMovie.Implementation.Validators
{
    public class MovieValidator : AbstractValidator<CreateMovieDto>
    {
        private readonly ProjectDbContext context;

        public MovieValidator(ProjectDbContext context)
        {
            RuleFor(x => x.Title)
                          .Cascade(CascadeMode.Stop)
                          .NotEmpty().WithMessage("Title is required")
                          .WithMessage("{PropertyName} is required")
                          .Matches(ValidFormatRegex.ValidNameFormat);

            RuleFor(x => x.ReleaseDate)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty().WithName("Release date");
                                    

            RuleFor(x => x.Runtime)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty()
                        .WithMessage("{PropertyName} is required")
                        .GreaterThan(1)
                        .LessThanOrEqualTo(400);

            RuleFor(x => x.CertificateId)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty()
                        .GreaterThan(0)
                        .Must(x => context.Certifications.Any(c => c.CertificationId == x))
                        .WithMessage("Certifacate doesnt exist.");

            this.context = context;
        }
    }
}
