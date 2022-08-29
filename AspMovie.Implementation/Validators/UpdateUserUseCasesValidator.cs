using AspMovie.Application.UseCases.Commands;
using AspMovie.DataAccess;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;


namespace AspMovie.Implementation.Validators
{
    public class UpdateUserUseCasesValidator : AbstractValidator<UpdateUserUseCasesDto>
    {
        public UpdateUserUseCasesValidator(ProjectDbContext context)
        {
            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("User is required.")
                .Must(x => context.Users.Any(u => u.Id == x))
                .WithMessage("User doesnt exist.");

            RuleFor(x => x.UseCaseIds)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Use cases are required")
                .Must(x => x.Count() == x.Distinct().Count())
                .WithMessage("Duplicate values are not allowed");

        }
    }
}
