using AspMovie.Application.UseCases.Dto;
using AspMovie.Implementation.Validators.Helper;
using AspMovie.DataAccess;
using FluentValidation;
using System.Linq;


namespace AspMovie.Implementation.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterDto>
    {
        public RegisterUserValidator(ProjectDbContext _context)
        {
            RuleFor(x => x.Email)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithName("Email Address")
               .EmailAddress().WithMessage("Invalid email address.")
               .Must(x => !_context.Users.Any(u => u.Email == x))
               .WithMessage("Email Address {PropertyValue} is already used.");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Length(3,12)
                .Matches(ValidFormatRegex.ValidUsernameFormat)
                .WithMessage(ValidFormatRegex.ValidUsernameFormatMsg)
                .Must(x => !_context.Users.Any(u => u.Username == x))
                .WithMessage("Username {PropertyValue} is already used.");

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Matches(ValidFormatRegex.ValidNameFormat)
                .WithMessage(ValidFormatRegex.ValidNameFormatMsg);

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Matches(ValidFormatRegex.ValidNameFormat)
                .WithMessage(ValidFormatRegex.ValidNameFormat);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Matches(ValidFormatRegex.ValidPasswordFormat)
                .WithMessage(ValidFormatRegex.ValidPasswordFormatMsg);

        }
    }
}
