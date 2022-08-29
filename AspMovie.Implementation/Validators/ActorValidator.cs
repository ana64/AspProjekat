using AspMovie.Application.UseCases.Queries.Dto;
using AspMovie.DataAccess;
using AspMovie.Implementation.Validators.Helper;
using FluentValidation;
using System;


namespace AspMovie.Implementation.Validators
{
    public class ActorValidator : AbstractValidator<ActorDto>
    {
        private readonly ProjectDbContext context;

        public ActorValidator(ProjectDbContext context)
        {
            RuleFor(x => x.FirstName)
                        .Cascade(CascadeMode.Stop)
                        .NotEmpty().WithMessage(Messages.FirstNameRequired)
                        .Matches(ValidFormatRegex.ValidNameFormat).WithMessage(ValidFormatRegex.ValidNameFormatMsg);

            RuleFor(x => x.LastName)
                       .Cascade(CascadeMode.Stop)
                       .NotEmpty().WithMessage(Messages.LastNameRequired)
                       .Matches(ValidFormatRegex.ValidNameFormat)
                       .WithMessage(ValidFormatRegex.ValidNameFormatMsg);

            RuleFor(x=>x.Birthday)
                        .Cascade(CascadeMode.Stop)
                        .LessThan(p => DateTime.Now) .WithMessage("Make sure you enter a correct date")
                        .When(x=>x.Birthday != null);

            RuleFor(x=>x.Biography)
                        .Cascade(CascadeMode.Stop)
                        .Length(10,200)
                        .When(x=>x.Biography != null);


            this.context = context;
        }


    }
}
