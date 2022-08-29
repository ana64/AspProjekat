using AspMovie.Application.UseCases.Commands;
using AspMovie.DataAccess;
using AspMovie.Domain;
using FluentValidation;
using AspMovie.Implementation.Validators;
using System.Linq;
using AspMovie.Implementation.UseCases;

namespace AspMovie.UseCases.Commands.Ef
{
    public class EfUpdateUserUseCasesCommand : EfUseCase, IUpdateUserUseCasesCommand
    {
        private readonly UpdateUserUseCasesValidator validator;
        public EfUpdateUserUseCasesCommand(ProjectDbContext context, UpdateUserUseCasesValidator validator) 
        : base(context)
        {
            this.validator = validator;
        }

        public int Id => 1;

        public string Name  =>"Update user actions";

        public string Description => "";

        public void Execute(UpdateUserUseCasesDto request)
        {
            validator.ValidateAndThrow(request);

            var userUseCases = Context.UserUseCases
                                      .Where(x => x.UserId == request.UserId)
                                      .ToList();

            Context.UserUseCases.RemoveRange(userUseCases);

            var useCasesToAdd = request.UseCaseIds.Select(x => new UserUseCase
            {
                UseCaseId = x,
                UserId = request.UserId.Value
            });

            Context.AddRange(useCasesToAdd);
            Context.SaveChanges();

        }
    }
}
