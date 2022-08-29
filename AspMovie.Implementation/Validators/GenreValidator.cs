using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Implementation.Validators.Helper;
using FluentValidation;


namespace AspMovie.Implementation.Validators
{
    public class GenreValidator : AbstractValidator<GenreDto>
    {
        private ProjectDbContext context;

        public GenreValidator(ProjectDbContext context)
        {
            RuleFor(x => x.Genre)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Genre is required.")
                 .Matches(ValidFormatRegex.ValidNameFormat);
                

            this.context = context;
        }
    }
}
