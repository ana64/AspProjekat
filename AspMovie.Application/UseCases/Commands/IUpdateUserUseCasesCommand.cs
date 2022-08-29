using System.Collections.Generic;


namespace AspMovie.Application.UseCases.Commands
{
    public interface IUpdateUserUseCasesCommand : ICommand<UpdateUserUseCasesDto> {  }
    public class UpdateUserUseCasesDto
    {
        public int? UserId { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
    }
}
