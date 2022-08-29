using AspMovie.Application.Emails;
using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Domain;
using AspMovie.Implementation.Validators;
using FluentValidation;

namespace AspMovie.Implementation.UseCases.Commands.Ef
{
    public class EfRegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private readonly RegisterUserValidator _validator;
        private readonly IEmailSender _sender;
        public EfRegisterUserCommand(ProjectDbContext context, RegisterUserValidator validator, IEmailSender sender) 
            : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 7;

        public string Name => "User reigstration";

        public string Description => "User registration using ef";

        public void Execute(RegisterDto request)
        {
            _validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = hash,
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            Context.Users.Add(user);
            Context.SaveChanges();

           
            var messageDto = new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration!",
                Body = $"Dear {request.Username}. Please activate your acount.."
            };

            _sender.Sand(messageDto);
           
        }
    }
}
