using AspMovie.Application.UseCases.Dto;
using System;


namespace AspMovie.Application.UseCases.Queries.Dto
{
    public class ActorDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Biography { get; set; }
    }
}
